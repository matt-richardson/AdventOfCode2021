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
        number.Should().Be((Pair)(1, 2));
    }
    
    [Test]
    public void CanParse_Example2()
    {
        var number = Number.Parse("[[1,2],3]");
        number.Should().Be((Pair)((1, 2), 3));
    }
    
    [Test]
    public void CanParse_Example3()
    {
        var number = Number.Parse("[9,[8,7]]");
        number.Should().Be((Pair)(9, (8, 7)));
    }
    
    [Test]
    public void CanParse_Example4()
    {
        var number = Number.Parse("[[1,9],[8,5]]");
        number.Should().Be((Pair)((1, 9), (8, 5)));
    }
    
    [Test]
    public void CanParse_Example5()
    {
        var number = Number.Parse("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]");
        number.Should().Be((Pair)((((1,2),(3,4)),((5,6),(7,8))),9));
    }
    
    [Test]
    public void CanParse_Example6()
    {
        var number = Number.Parse("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]");
        number.Should().Be((Pair)(((9,(3,8)),((0,9),6)),(((3,7),(4,9)),3)));
    }
    
    [Test]
    public void CanParse_Example7()
    {
        var number = Number.Parse("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]");
        number.Should().Be((Pair)((((1,3),(5,3)),((1,3),(8,7))),(((4,9),(6,9)),((8,2),(7,3)))));
    }

    [Test]
    public void CanAdd()
    {
        var left = Number.Parse("[1,2]");
        var right = Number.Parse("[[3,4],5]");
        var answer = left + right;
        answer.ToString().Should().Be("[[1,2],[[3,4],5]]");
    }
    
    [Test]
    [TestCase("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
    [TestCase("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
    [TestCase("[[6,[5,[4,[3,2]]]],1]", "[[6,[5,[7,0]]],3]")]
    [TestCase("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
    [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
    public void CanExplode(string input, string expected)
    {
        var number = Number.Parse(input);
        var result = ((Pair)number).Explode();
        result.Should().BeTrue();
        ((Pair)number).ToString().Should().Be(expected);
    }

    [Test]
    [TestCase(10,"[5,5]")]
    [TestCase(11,"[5,6]")]
    [TestCase(12,"[6,6]")]
    public void CanSplit(int input, string expected)
    {
        var number = new RegularNumber(input);
        var result = RegularNumber.TrySplit(number, out var pair);
        result.Should().BeTrue();
        pair.Should().NotBeNull();
        pair!.ToString().Should().Be(expected);
    }
    
    [Test]
    public void WontSplitIfUnderTen()
    {
        var number = new RegularNumber(9);
        var result = RegularNumber.TrySplit(number, out var pair);
        result.Should().BeFalse();
        pair.Should().BeNull();
    }

    [Test]
    public void CanReduce()
    {
        var number = Number.Parse("[[[[4,3],4],4],[7,[[8,4],9]]]") + Number.Parse("[1,1]");
        number.Reduce();
        number.ToString().Should().Be("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]");
    }
}