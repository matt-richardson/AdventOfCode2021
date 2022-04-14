using NUnit.Framework;

[TestFixture]
public class Tests
{
    string[] plannedCourse = new string[]
    {
        "forward 5",
        "down 5",
        "forward 8",
        "up 3",
        "down 8",
        "forward 2",
    };

    [Test]
    public void Part1()
    {
        Assert.That(Program.CalculatePart1(plannedCourse), Is.EqualTo(150));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Program.CalculatePart2(plannedCourse), Is.EqualTo(900));
    }
}
