namespace Puzzles.Day14ExtendedPolymerization;

public class PolymerInstructions
{
    public PolymerInstructions(string[] input)
    {
        Template = new PolymerTemplate(input.First());

        Rules = input.Skip(2).Select(PairInsertionRule.Create).ToArray();
    }

    public IReadOnlyCollection<PairInsertionRule> Rules { get; }

    public PolymerTemplate Template { get; }
}
