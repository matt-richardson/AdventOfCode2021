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

    [Test]
    public void CanAddUpListOfNumbers_Example1()
    {
        var numbers = new[]
        {
            Number.Parse("[1,1]"),
            Number.Parse("[2,2]"),
            Number.Parse("[3,3]"),
            Number.Parse("[4,4]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[1,1],[2,2]],[3,3]],[4,4]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example2()
    {
        var numbers = new[]
        {
            Number.Parse("[1,1]"),
            Number.Parse("[2,2]"),
            Number.Parse("[3,3]"),
            Number.Parse("[4,4]"),
            Number.Parse("[5,5]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[3,0],[5,3]],[4,4]],[5,5]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example3()
    {
        var numbers = new[]
        {
            Number.Parse("[1,1]"),
            Number.Parse("[2,2]"),
            Number.Parse("[3,3]"),
            Number.Parse("[4,4]"),
            Number.Parse("[5,5]"),
            Number.Parse("[6,6]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[5,0],[7,4]],[5,5]],[6,6]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example4()
    {
        var numbers = new[]
        {
            Number.Parse("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]"),
            Number.Parse("[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]"),
            Number.Parse("[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]"),
            Number.Parse("[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]"),
            Number.Parse("[7,[5,[[3,8],[1,4]]]]"),
            Number.Parse("[[2,[2,2]],[8,[8,1]]]"),
            Number.Parse("[2,9]"),
            Number.Parse("[1,[[[9,3],9],[[9,0],[0,7]]]]"),
            Number.Parse("[[[5,[7,4]],7],1]"),
            Number.Parse("[[[[4,2],2],6],[8,7]]"),

        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example4a()
    {
        var numbers = new[]
        {
            Number.Parse("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]"),
            Number.Parse("[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]"),

        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example4b()
    {
        var numbers = new[]
        {
            Number.Parse("[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]"),
            Number.Parse("[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[6,7],[6,7]],[[7,7],[0,7]]],[[[8,7],[7,7]],[[8,8],[8,0]]]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example4c()
    {
        var numbers = new[]
        {
            Number.Parse("[[[[6,7],[6,7]],[[7,7],[0,7]]],[[[8,7],[7,7]],[[8,8],[8,0]]]]"),
            Number.Parse("[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[7,0],[7,7]],[[7,7],[7,8]]],[[[7,7],[8,8]],[[7,7],[8,7]]]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example4d()
    {
        var numbers = new[]
        {
            Number.Parse("[[[[7,0],[7,7]],[[7,7],[7,8]]],[[[7,7],[8,8]],[[7,7],[8,7]]]]"),
            Number.Parse("[7,[5,[[3,8],[1,4]]]]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[7,7],[7,8]],[[9,5],[8,7]]],[[[6,8],[0,8]],[[9,9],[9,0]]]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example4e()
    {
        var numbers = new[]
        {
            Number.Parse("[[[[7,7],[7,8]],[[9,5],[8,7]]],[[[6,8],[0,8]],[[9,9],[9,0]]]]"),
            Number.Parse("[[2,[2,2]],[8,[8,1]]]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[6,6],[6,6]],[[6,0],[6,7]]],[[[7,7],[8,9]],[8,[8,1]]]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example4f()
    {
        var numbers = new[]
        {
            Number.Parse("[[[[6,6],[6,6]],[[6,0],[6,7]]],[[[7,7],[8,9]],[8,[8,1]]]]"),
            Number.Parse("[2,9]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[6,6],[7,7]],[[0,7],[7,7]]],[[[5,5],[5,6]],9]]");
    }

    [Test]
    public void CanAddUpListOfNumbers_Example4g()
    {
        var numbers = new[]
        {
            Number.Parse("[[[[6,6],[7,7]],[[0,7],[7,7]]],[[[5,5],[5,6]],9]]"),
            Number.Parse("[1,[[[9,3],9],[[9,0],[0,7]]]]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[7,8],[6,7]],[[6,8],[0,8]]],[[[7,7],[5,0]],[[5,5],[5,6]]]]");
    }
    
    [Test]
    public void CanAddUpListOfNumbers_Example4h()
    {
        var numbers = new[]
        {
            Number.Parse("[[[[7,8],[6,7]],[[6,8],[0,8]]],[[[7,7],[5,0]],[[5,5],[5,6]]]]"),
            Number.Parse("[[[5,[7,4]],7],1]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[7,7],[7,7]],[[8,7],[8,7]]],[[[7,0],[7,7]],9]]");
    }

    [Test]
    public void CanAddUpListOfNumbers_Example4i()
    {
        var numbers = new[]
        {
            Number.Parse("[[[[7,7],[7,7]],[[8,7],[8,7]]],[[[7,0],[7,7]],9]]"),
            Number.Parse("[[[[4,2],2],6],[8,7]]"),
        };
        var result = Number.Add(numbers);
        result.ToString().Should().Be("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");
    }

    [Test]
    [TestCase("[9,1]", 29)]
    [TestCase("[1,9]", 21)]
    [TestCase("[[9,1],[1,9]]", 129)]
    [TestCase("[[1,2],[[3,4],5]]", 143)]
    [TestCase("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
    [TestCase("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
    [TestCase("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
    [TestCase("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
    [TestCase("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
    public void CanCalculateMagnitude(string input, int answer)
    {
        var number = Number.Parse(input);
        number.Magnitude().Should().Be(answer);
    }
}