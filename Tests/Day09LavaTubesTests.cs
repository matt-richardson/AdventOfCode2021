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
        var results = new Map(input);
        
        var topLeft = new Point(0, 0, 2);
        var topMiddle = new Point(0, 1, 1);
        var topRight = new Point(0, 2, 9);

        var middleLeft = new Point(1, 0, 3);
        var middleMiddle = new Point(1, 1, 9);
        var middleRight = new Point(1, 2, 8);

        var bottomLeft = new Point(2, 0, 9);
        var bottomMiddle = new Point(2, 1, 8);
        var bottomRight = new Point(2, 2, 5);
        
        results.Points().Should().BeEquivalentTo(new[]
        {
            topLeft.WithNeighbours(null, middleLeft, null, topMiddle),
            topMiddle.WithNeighbours(null, middleMiddle, topLeft, topRight),
            topRight.WithNeighbours(null, middleRight, topMiddle, null),
            middleLeft.WithNeighbours(topLeft, bottomLeft, null, middleMiddle),
            middleMiddle.WithNeighbours(topMiddle, bottomMiddle, middleLeft, middleRight),
            middleRight.WithNeighbours(topRight, bottomRight, middleMiddle, null),
            bottomLeft.WithNeighbours(middleLeft, null, null, bottomMiddle),
            bottomMiddle.WithNeighbours(middleMiddle, null, bottomLeft, bottomRight),
            bottomRight.WithNeighbours(middleRight, null, bottomMiddle, null),
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
        Day09LavaTubes.CalculatePart2(sampleData).Should().Be(1134);
    }
}
