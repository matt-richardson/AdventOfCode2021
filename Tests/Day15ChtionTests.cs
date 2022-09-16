using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day15Chiton;

namespace Tests;

[TestFixture]
public class Day15ChitonTests
{
    [Test]
    public void CalculatesPart1()
    {
        Console.WriteLine(new Day15Chiton().CalculatePart1());
    }

    [Test]
    public void CalculatesPart2()
    {
        Console.WriteLine(new Day15Chiton().CalculatePart2());
    }

    [Test]
    public void CalculateFromExample()
    {
        var sampleData = new string [] {
            "1163751742",
            "1381373672",
            "2136511328",
            "3694931569",
            "7463417111",
            "1319128137",
            "1359912421",
            "3125421639",
            "1293138521",
            "2311944581",
        };
        var riskMap = new RiskMap(sampleData);
        riskMap.CalculateLowestRiskPath().Should().Be(40);
    }
}
