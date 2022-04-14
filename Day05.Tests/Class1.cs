using NUnit.Framework;

[TestFixture]
public class Tests
{
    string[] vents = new string[]
    {
        "0,9 -> 5,9",
        "8,0 -> 0,8",
        "9,4 -> 3,4",
        "2,2 -> 2,1",
        "7,0 -> 7,4",
        "6,4 -> 2,0",
        "0,9 -> 2,9",
        "3,4 -> 1,4",
        "0,0 -> 8,8",
        "5,5 -> 8,2",
    };

    [Test]
    public void Part1()
    {
        Assert.That(Program.CalculatePart1(vents), Is.EqualTo(5));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Program.CalculatePart2(vents), Is.EqualTo(12));
    }
}
