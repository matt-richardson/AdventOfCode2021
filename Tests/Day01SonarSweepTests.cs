using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using Puzzles.Day01SonarSweep;

namespace Tests;

[TestFixture]
public class Day01SonarSweepTests
{
    string[] sonarReadings = new string[]
    {
        "199",
        "200",
        "208",
        "210",
        "200",
        "207",
        "240",
        "269",
        "260",
        "263",
    };

    [Test]
    public void Part1()
    {
        Assert.That(Day01SonarSweep.CalculatePart1(sonarReadings), Is.EqualTo(7));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Day01SonarSweep.CalculatePart2(sonarReadings), Is.EqualTo(5));
    }
}
