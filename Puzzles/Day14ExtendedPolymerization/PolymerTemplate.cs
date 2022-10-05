using System.Text;

namespace Puzzles.Day14ExtendedPolymerization;

public class PolymerTemplate
{
    public PolymerTemplate(string template)
    {
        Template = template;
        Length = template.Length;
        DistinctChars = template.Distinct().ToArray();
        CountOfMostCommonElement = DistinctChars.Max(GetElementCount);
        CountOfLeastCommonElement = DistinctChars.Min(GetElementCount);
    }

    private int Length { get; }

    private IEnumerable<char> DistinctChars { get;  }

    private string Template { get;  }

    public PolymerTemplate Apply(PairInsertionRule rule) => Apply(new[] {rule});

    public string Render() => Template;

    public PolymerTemplate Apply(IReadOnlyCollection<PairInsertionRule> rules)
    {
        var result = new StringBuilder();
        foreach(var (firstElement, secondElement) in Template.Zip(Template.Skip(1)))
        {
            result.Append(firstElement);
            if (rules.Count(x => x.Left == firstElement && x.Right == secondElement) > 1)
                throw new Exception();
            var rule = rules.FirstOrDefault(x => x.Left == firstElement && x.Right == secondElement);
            if (rule != null)
                result.Append(rule.Insert);
        }

        result.Append(Template.Last());

        var newTemplate = new PolymerTemplate(result.ToString());
        //Console.WriteLine(newTemplate.Render());
        return newTemplate;
    }

    public long GetElementCount(char @char) => Template.Count(x => x == @char);

    public long CountOfMostCommonElement { get; }
    
    public long CountOfLeastCommonElement { get; }

    public PolymerTemplate Apply(IReadOnlyCollection<PairInsertionRule> rules, int numberOfSteps)
    {
        return Enumerable.Range(1, numberOfSteps)
            .Aggregate(this, (template, step) =>
            {
                Console.WriteLine($"At step {step}, the template is {template.Length} long");
                return template.Apply(rules);
            });
    }
}
