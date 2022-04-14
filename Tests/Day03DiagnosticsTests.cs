using NUnit.Framework;
using Puzzles.Day03_Diagnostics;

namespace Tests;

[TestFixture]
public class Day03DiagnosticsTests
{
    string[] diagnosticReport = new string[]
    {
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010",
    };

    [Test]
    public void Part1()
    {
        Assert.That(Day03Diagnostics.CalculatePart1(diagnosticReport), Is.EqualTo(198));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Day03Diagnostics.CalculatePart2(diagnosticReport), Is.EqualTo(230));
    }
}
