using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day13TransparentOrigami;

namespace Tests;

[TestFixture]
public class Day13TransparentOrigamiTests
{
    [Test]
    public void CalculatesPart1()
    {
        Console.WriteLine(new Day13TransparentOrigami().CalculatePart1());
    }

    [Test]
    public void CalculatesPart2()
    {
        Console.WriteLine(new Day13TransparentOrigami().CalculatePart2());
    }

    class Parsing
    {
        private readonly OrigamiInstructions instructions;

        public Parsing()
        {
            var sampleData = new[]
            {
                "6,10",
                "0,14",
                "9,10",
                "0,3",
                "10,4",
                "4,11",
                "6,0",
                "6,12",
                "4,1",
                "0,13",
                "10,12",
                "3,4",
                "3,0",
                "8,4",
                "1,10",
                "2,14",
                "8,10",
                "9,0",
                "",
                "fold along y=7",
                "fold along x=5",
            };

            instructions = new OrigamiInstructions(sampleData);
        }
        
        [Test]
        public void CanParsePaper()
        {
            instructions.Paper.Render().Should().Equal(new[]
            {
                "...#..#..#.",
                "....#......",
                "...........",
                "#..........",
                "...#....#.#",
                "...........",
                "...........",
                "...........",
                "...........",
                "...........",
                ".#....#.##.",
                "....#......",
                "......#...#",
                "#..........",
                "#.#........",
            });
        }
        
        [Test]
        public void CanParseFolds()
        {
            instructions.Folds.Should().Equal(new Fold[]
            {
                new FoldUp(7),
                new FoldLeft(5),
            });
        }
        
        [Test]
        public void CanCalculateNumberOfDots()
        {
            instructions.Paper.VisibleDotCount().Should().Be(18);
        }
        
        [Test]
        public void CanFold()
        {
            var result = instructions.Paper.Fold(new FoldUp(7));
            result.Render().Should().Equal(new[]
            {
                "#.##..#..#.",
                "#...#......",
                "......#...#",
                "#...#......",
                ".#.#..#.###",
                "...........",
                "...........",
            });
            result.VisibleDotCount().Should().Be(17);
        }
        
        [Test]
        public void CanFoldTwice()
        {
            var result = instructions.Paper
                .Fold(new FoldUp(7))
                .Fold(new FoldLeft(5));
            result.Render().Should().Equal(new[]
            {
                "#####",
                "#...#",
                "#...#",
                "#...#",
                "#####",
                ".....",
                ".....",
            });
            result.VisibleDotCount().Should().Be(16);
        }
    }
}
