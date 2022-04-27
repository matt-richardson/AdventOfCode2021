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
    public void Part2()
    {
        throw new NotImplementedException();
    }
}
