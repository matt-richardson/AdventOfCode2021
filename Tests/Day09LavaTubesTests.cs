using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day09LavaTubes;
namespace Tests;

[TestFixture]
public class Day09LavaTubesTests
{
    string[] sampleData = {
        "2199943210",
        "3987894921",
        "9856789892",
        "8767896789",
        "9899965678"
    };

    [Test]
    public void Part1()
    {
        Assert.That(Day09LavaTubes.CalculatePart1(sampleData), Is.EqualTo(15));
    }

    [Test]
    public void CanParseSingleRow()
    {
        var input = "2199943210";
        var results = input.Parse();
        results.Length.Should().Be(input.Length);
    }   
    [Test]
    public void CanParseMultipleRows()
    {
        string[] input = {
            "219",
            "398",
            "985"
        };
        var results = input.Parse();
        results.Should().BeEquivalentTo(new[]
        {
            new Point(0, 0, 2, null, 3, null, 1),
            new Point(0, 1, 1, null, 9, 2, 9),
            new Point(0, 2, 9, null, 8, 1, null),

            new Point(1, 0, 3, 2, 9, null, 9),
            new Point(1, 1, 9, 1, 8, 3, 8),
            new Point(1, 2, 8, 9, 5, 9, null),

            new Point(2, 0, 9, 3, null, null, 8),
            new Point(2, 1, 8, 9, null, 9, 5),
            new Point(2, 2, 5, 8, null, 8, null),
        });
    }
    
    [Test]
    public void CanSandwich()
    {
        var input = new int?[] { 1, 2, 3 };
        var results = input.Sandwich();
        results.Should().BeEquivalentTo(new (int, int?, int, int?)[]
            {
                (0, null, 1, 2),
                (1, 1, 2, 3),
                (2, 2, 3, null),
            }
        );
    }
    
    [Test]
    public void Part2()
    {
        throw new NotImplementedException();
    }
}
