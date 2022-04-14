using NUnit.Framework;

[TestFixture]
public class Tests
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
        Assert.That(Program.CalculatePart1(sonarReadings), Is.EqualTo(7));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Program.CalculatePart2(sonarReadings), Is.EqualTo(5));
    }
}
