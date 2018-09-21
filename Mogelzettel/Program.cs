using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mogelzettel
{
    public class Program
    {
        /// <summary>
        /// Zeichen, dad eine Mine repräsentiert.
        /// </summary>
        const char Mine = '*';

        /// <summary>
        /// Richtungen für die Berechnung der Koordinaten, die auf Minen geprüft werden sollen.
        /// </summary>
        static readonly int[] Directions = { -1, 0, 1 };

        /// <summary>
        /// Berechnet die Anzahl der Minen in den benachbarten Feldern ausgehend von einem Feld.
        /// </summary>
        /// <param name="fields">Spielfeld</param>
        /// <param name="row">Index der Ausgangszeile</param>
        /// <param name="column">Index der Spalte</param>
        /// <returns>Anzahl der Minen in den benachbarten Feldern</returns>
        static int CountAdjacentMines(IEnumerable<string> fields, int row, int column)
        {
            return
                // Neue Koordinaten rund um das Ausgangsfeld berechnen.
                // Diese sollen auf Minen geprüft werden.
                (from dRow in Directions
                let newRow = row + dRow
                from dColumn in Directions
                let newColumn = column + dColumn
                where
                    // Prüfung, ob die neuen Koordinaten innerhalb der Spielfeldgrenzen liegen.
                    newRow.IsInRange(fields.Count()) && newColumn.IsInRange(fields.First().Length)
                    // Das Ausgangsfeld soll ignoriert werden.
                    && !(newRow == row && newColumn == column)
                    // Nur Felder mit einer Mine sollen zählen.
                    && fields.ElementAt(newRow)[newColumn] == Mine
                select 1)
                .Sum();
        }

        /// <summary>
        /// Liest das Spielfeld aus einer Textdatei ein, erzeugt den Mogelzettel und schreibt diesen in eine weitere Textdatei.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] fields = File.ReadAllLines(args[0]);
            WriteFields(fields);
            Console.WriteLine();
            IEnumerable<string> cribSheet = CreateCribSheet(fields);
            WriteFields(cribSheet);
            File.WriteAllLines(args[1], cribSheet);
            Console.ReadLine();
        }

        /// <summary>
        /// Erzeugt den Mogelzettel.
        /// </summary>
        /// <param name="fields">Spielfeld, für das der Mogelzettel erzeugt werden soll.</param>
        /// <returns>
        /// Mogelzettel mit den gleichen Dimensionen wie das Spielfeld.
        /// Dieser enthält je Feld entweder eine Mine oder die Anzahl der Minen in den benachbarten Feldern.
        /// </returns>
        public static IEnumerable<string> CreateCribSheet(string[] fields)
        {
            return
                // Projektion der Koordinaten
                Enumerable.Range(0, fields.Length).Select(row =>
                    new String(Enumerable.Range(0, fields[0].Length).Select(column =>
                        // Prüfung, ob das aktuelle Feld eine Mine enthält.
                        fields[row][column] == Mine
                            // Der Mogelzettel soll an der gleichen Koordinate eine Mine enthalten.
                            ? Mine
                            // Es soll die Anzahl der benachbarten Minen berechnet werden.
                            : CountAdjacentMines(fields, row, column).ToChar())
                    .ToArray()));
        }

        /// <summary>
        /// Gibt das Spielfeld auf der Konsole aus.
        /// </summary>
        /// <param name="fields">Das Spielfeld</param>
        static void WriteFields(IEnumerable<string> fields) =>
            Console.WriteLine(String.Join(Environment.NewLine, fields));
    }
}
