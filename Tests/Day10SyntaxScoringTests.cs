
using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day10SyntaxScoring;

namespace Tests;

[TestFixture]
public class Day10SyntaxScoringTests 
{
    string[] sampleData = {
        "[({(<(())[]>[[{[]{<()<>>",
        "[(()[<>])]({[<{<<[]>>(",
        "{([(<{}[<>[]}>{[]{[(<()>",
        "(((({<>}<{<{<>}{[]{[]{}",
        "[[<[([]))<([[{}[[()]]]",
        "[{[{({}]{}}([{[{{{}}([]",
        "{<[[]]>}<{[{[{[]{()[[[]",
        "[<(<(<(<{}))><([]([]()",
        "<{([([[(<>()){}]>(<<{{",
        "<{([{{}}[<[[[<>{}]]]>[]]",
    };

    [Test]
    [TestCase("()")]
    [TestCase("[]")]
    [TestCase("([])")]
    [TestCase("{()()()}")]
    [TestCase("<([{}])>")]
    [TestCase("[<>({}){}[([])<>]]")]
    [TestCase("(((((((((())))))))))")]
    public void CanParseSuccessfulLines(string input)
    {
        var result = LineParser.Parse(input);
        result.Should().BeOfType(typeof(SuccessfullyParsedLine));
    }

    [Test]
    [TestCase("(]", ')', ']')]
    [TestCase("{()()()>", '}', '>')]
    [TestCase("(((()))}", ')', '}')]
    [TestCase("<([]){()}[{}])", '>', ')')]
    public void ParsingInvalidData(string input, char expected, char found)
    {
        var result = LineParser.Parse(input);
        result.Should().BeOfType(typeof(SyntaxError));
        ((SyntaxError) result).Expected.Should().Be(expected);
        ((SyntaxError) result).Found.Should().Be(found);
    }

    [Test]
    public void ParsingSampleData()
    {
        var result = new NavigationSubsystem(sampleData);
        result.SyntaxErrors().Count().Should().Be(5);
    }
    
    [Test]
    public void Part1()
    {
        Day10SyntaxScoring.CalculatePart1(sampleData).Should().Be(26397);
    }
    
    [Test]
    public void Part2()
    {
        throw new NotImplementedException();
        //Day10SyntaxScoring.CalculatePart2(sampleData).Should().Be(1134);
    }
}

