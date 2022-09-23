using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day18SnailFish;

namespace Tests;

[TestFixture]
public class Day18SnailFishTests
{
    [Test]
    public void CanParse_Example1()
    {
        var number = Number.Parse("[1,2]");
        number.Should().Be(new Pair(1, 2));
    }
    
    [Test]
    public void CanParse_Example2()
    {
        var number = Number.Parse("[[1,2],3]");
        number.Should().Be(new Pair((1, 2), 3));
    }
    
    [Test]
    public void CanParse_Example3()
    {
        var number = Number.Parse("[9,[8,7]]");
        number.Should().Be(new Pair(9, (8, 7)));
    }
    
    [Test]
    public void CanParse_Example4()
    {
        var number = Number.Parse("[[1,9],[8,5]]");
        number.Should().Be(new Pair((1, 9), (8, 5)));
    }
    
    [Test]
    public void CanParse_Example5()
    {
        var number = Number.Parse("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]");
        number.Should().Be(new Pair((((1,2),(3,4)),((5,6),(7,8))),9));
    }
    
    [Test]
    public void CanParse_Example6()
    {
        var number = Number.Parse("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]");
        number.Should().Be(new Pair(((9,(3,8)),((0,9),6)),(((3,7),(4,9)),3)));
    }
    
    [Test]
    public void CanParse_Example7()
    {
        var number = Number.Parse("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]");
        number.Should().Be(new Pair((((1,3),(5,3)),((1,3),(8,7))),(((4,9),(6,9)),((8,2),(7,3)))));
    }
}