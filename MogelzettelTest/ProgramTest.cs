using Mogelzettel;
using System;
using Xunit;

namespace MogelzettelTest
{
    public class ProgramTest
    {
        [Fact]
        public void CreateCribSheetTest1()
        {
            var fields = new []
            {
                "*...",
                "....",
                ".*..",
                "...."
            };
            var expected = new[]
            {
                "*100",
                "2210",
                "1*10",
                "1110"
            };
            Assert.Equal(expected, Program.CreateCribSheet(fields));
        }

        [Fact]
        public void CreateCribSheetTest2()
        {
            var fields = new[]
            {
                "**...",
                ".....",
                ".*..."
            };
            var expected = new[]
            {
                "**100",
                "33200",
                "1*100"
            };
            Assert.Equal(expected, Program.CreateCribSheet(fields));
        }

        [Fact]
        public void CreateCribSheetTest3()
        {
            var fields = new[]
            {
                "*"
            };
            var expected = new[]
            {
                "*"
            };
            Assert.Equal(expected, Program.CreateCribSheet(fields));
        }

        [Fact]
        public void CreateCribSheetTest4()
        {
            var fields = new[]
            {
                "."
            };
            var expected = new[]
            {
                "0"
            };
            Assert.Equal(expected, Program.CreateCribSheet(fields));
        }
    }
}
