using NUnit.Framework;

[TestFixture]
public class Tests
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
        Assert.That(Program.CalculatePart1(diagnosticReport), Is.EqualTo(198));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Program.CalculatePart2(diagnosticReport), Is.EqualTo(230));
    }
}
