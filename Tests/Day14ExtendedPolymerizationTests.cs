using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day14ExtendedPolymerization;

namespace Tests;

[TestFixture]
public class Day14ExtendedPolymerizationTests
{
    [Test]
    public void CalculatesPart1()
    {
        Console.WriteLine(new Day14ExtendedPolymerization().CalculatePart1());
    }

    [Test]
    public void CalculatesPart2()
    {
        Console.WriteLine(new Day14ExtendedPolymerization().CalculatePart2());
    }

    class Parsing
    {
        private readonly PolymerInstructions instructions;
        public Parsing()
        {
            var sampleData = new[]
            {
                "NNCB",
                "",
                "CH -> B",
                "HH -> N",
                "CB -> H",
                "NH -> C",
                "HB -> C",
                "HC -> B",
                "HN -> C",
                "NN -> C",
                "BH -> H",
                "NC -> B",
                "NB -> B",
                "BN -> B",
                "BB -> N",
                "BC -> B",
                "CC -> N",
                "CN -> C",
            };

            instructions = new PolymerInstructions(sampleData);
        }

        [Test]
        public void CanParseTemplate()
        {
            instructions.Template.Render().Should().Be("NNCB");
        }
        
        [Test]
        public void CanParseRules()
        {
            instructions.Rules.Select(x => x.ToString()).Should().BeEquivalentTo(new []
            {
                "CH -> B",
                "HH -> N",
                "CB -> H",
                "NH -> C",
                "HB -> C",
                "HC -> B",
                "HN -> C",
                "NN -> C",
                "BH -> H",
                "NC -> B",
                "NB -> B",
                "BN -> B",
                "BB -> N",
                "BC -> B",
                "CC -> N",
                "CN -> C",
            });
        }

        [Test]
        public void CanApplyNoOpRule()
        {
            var result = instructions.Template.Apply(new PairInsertionRule("CH -> B"));
            result.Render().Should().Be("NNCB");
        }
        
        [Test]
        public void CanApplyModifyingRule()
        {
            var result = instructions.Template.Apply(new PairInsertionRule("NN -> C"));
            result.Render().Should().Be("NCNCB");
        }
        
        [Test]
        public void CanApplyRules()
        {
            var result = instructions.Template.Apply(instructions.Rules);
            result.Render().Should().Be("NCNBCHB");

            result = result.Apply(instructions.Rules);
            result.Render().Should().Be("NBCCNBBBCBHCB");
            
            result = result.Apply(instructions.Rules);
            result.Render().Should().Be("NBBBCNCCNBBNBNBBCHBHHBCHB");
            
            result = result.Apply(instructions.Rules);
            result.Render().Should().Be("NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB");
        }

        [Test]
        public void CanApplyRules10Times()
        {
            var result = instructions.Template.Apply(instructions.Rules, 10);
         
            result.Render().Length.Should().Be(3073);
            result.GetElementCount('B').Should().Be(1749);
            result.GetElementCount('C').Should().Be(298);
            result.GetElementCount('H').Should().Be(161);
            result.GetElementCount('N').Should().Be(865);

            (result.CountOfMostCommonElement - result.CountOfLeastCommonElement).Should().Be(1588);
        }
        
    }
}
