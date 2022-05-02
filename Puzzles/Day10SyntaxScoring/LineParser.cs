namespace Puzzles.Day10SyntaxScoring;

public class LineParser
{
    private static Dictionary<char, char> matchedPairs = new Dictionary<char, char>()
    {
        {'(', ')'},
        {'{', '}'},
        {'<', '>'},
        {'[', ']'},
    };

    public static ParseResult Parse(string input)
    {
        var opens = new Stack<char>();
        foreach (var character in input)
        {
            if (IsValidOpeningBracket(character))
                opens.Push(character);
            else if (!IsValidClosingBracket(character))
                throw new InvalidDataException("Unexpected input char " + character);
            else
            {
                var last = opens.Pop();
                var expected = matchedPairs[last];
                if (character != expected)
                    return new SyntaxError(expected, character);
            }
        }

        return new SuccessfullyParsedLine();
    }

    private static bool IsValidClosingBracket(char character) => matchedPairs.ContainsValue(character);

    private static bool IsValidOpeningBracket(char character) => matchedPairs.ContainsKey(character);
}
