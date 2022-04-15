using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day08SevenSegmentDisplays;

namespace Tests;

[TestFixture]
public class Day08SevenSegmentDisplaysTests
{
    string[] sampleData = {
        "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
        "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
        "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
        "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
        "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
        "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
        "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
        "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
        "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
        "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce",
    };

    [Test]
    public void Part1()
    {
        Assert.That(Day08SevenSegmentDisplays.CalculatePart1(sampleData), Is.EqualTo(26));
    }

    [Test]
    public void CanParse()
    {
        //"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"
        var results =
            "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf".Parse();

        //note - the signals have been sorted alphabetically
        results.signals.Should<string>().BeEquivalentTo(new[]
            {"abcdefg", "bcdef", "acdfg", "abcdf", "abd", "abcdef", "bcdefg", "abef", "abcdeg", "ab"});
        results.displays.Should<string>().BeEquivalentTo(new[]
            {"bcdef", "abcdf", "bcdef", "abcdf"});
    }

    [Test]
    public void CanResolveSignalsToNumbers()
    {
        //"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"
        var results = Day08SevenSegmentDisplays.ResolveSignalsToNumbers(
            new [] { "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab" }
        );
        results[8].Should().Be("acedgfb");
        results[5].Should().Be("cdfbe");
        results[2].Should().Be("gcdfa");
        results[3].Should().Be("fbcad");
        results[7].Should().Be("dab");
        results[9].Should().Be("cefabd");
        results[6].Should().Be("cdfgeb");
        results[4].Should().Be("eafb");
        results[0].Should().Be("cagedb");
        results[1].Should().Be("ab");
    }

    [Test]
    public void CanMatchDisplayToResolvedSignals()
    {
        //note - the signals have been sorted alphabetically
        var results = Day08SevenSegmentDisplays.GetDisplayReadout(
            //ordered
            new [] { "abcdeg", "ab", "acdfg", "abcdf", "abef", "bcdef", "bcdefg", "abd", "abcdefg", "abcdef"},
            new [] {"bcdef", "abcdf", "bcdef", "abcdf"}
        );
        results.Should().Be(5353);
    }

    [Test]
    public void Part2()
    {
        Day08SevenSegmentDisplays.CalculatePart2(sampleData).Should().Be(61229);
    }
}
