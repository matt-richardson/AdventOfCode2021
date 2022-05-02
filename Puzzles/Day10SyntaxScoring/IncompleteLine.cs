namespace Puzzles.Day10SyntaxScoring;

public class IncompleteLine : ParseResult
{
    public IncompleteLine(string autoComplete)
    {
        AutoComplete = autoComplete;
    }

    public string AutoComplete { get; }

    public long Score => AutoComplete.ToCharArray().Aggregate(0l, (accum, curr) => accum * 5 + GetPoints(curr));

    int GetPoints(char c) => c switch
        {
            ')' => 1,
            ']' => 2,
            '}' => 3,
            '>' => 4,
            _ => throw new InvalidDataException($"Unexpected input char {c}")
        };
}
