using NUnit.Framework;
using Puzzles.Day07Whales;

namespace Tests;

[TestFixture]
public class Day07WhalesTests
{
    string crabPositions = "16,1,2,0,4,2,7,1,2,14";

    [Test]
    public void Part1()
    {
        Assert.That(Day07Whales.CalculatePart1(crabPositions), Is.EqualTo(37));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Day07Whales.CalculatePart2(crabPositions), Is.EqualTo(168));
    }
}
