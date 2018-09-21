using System;
using System.Collections.Generic;
using System.Text;

namespace Mogelzettel
{
    static internal class IntExtensions
    {
        /// <summary>
        /// Prüft, ob eine Zahl innerhalb zwischen Null und einer Grenze liegt, 0 &lt;= <paramref name="i"/> &lt; <paramref name="range"/>.
        /// </summary>
        /// <param name="i">Zahl, die geprüft werden soll.</param>
        /// <param name="range">Grenze, auf die gerpüft werden soll.</param>
        /// <returns>True, wenn die Zahl innerhalb der Grenzen liegt.</returns>
        static internal bool IsInRange(this int i, int range) => i >= 0 && i < range;

        /// <summary>
        /// Konvertiert eine Ziffer in das entsprechende Zeichen.
        /// 0 => '0', 1 => '1', usw.
        /// </summary>
        /// <param name="i">Ziffer, die konvertiert werden soll.</param>
        /// <returns>Zeichen, das die Ziffer repräsentiert.</returns>
        static internal char ToChar(this int i) => (char)(i + '0');
    }
}
