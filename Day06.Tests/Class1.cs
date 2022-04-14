using NUnit.Framework;

[TestFixture]
public class Tests
{
    string fish = "3,4,3,1,2";

    [Test]
    public void Part1()
    {
        Assert.That(Program.CalculatePart1(fish, 18), Is.EqualTo(26));
        Assert.That(Program.CalculatePart1(fish, 80), Is.EqualTo(5934));
    }

    [Test]
    public void Part2()
    {
        Assert.That(Program.CalculatePart1(fish, 256), Is.EqualTo(26984457539));
    }
}
