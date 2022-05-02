namespace Puzzles.Day10SyntaxScoring;

public class LineParser
{
    public static ParseResult Parse(string input)
    {
        var opens = new Stack<char>();
        foreach (var character in input)
        {
            if (character is '(' or '{' or '<' or '[') //todo - put into matched lookup
            {
                opens.Push(character);
            }
            else
            {
                var last = opens.Pop();
                var expected = GetMatchedPair(last);
                if (character != expected)
                    return new SyntaxError(expected, character);
            }
        }

        return new SuccessfullyParsedLine();
    }

    private static char GetMatchedPair(char inputChar)
    {
        return inputChar switch
        {
            '(' => ')',
            '[' => ']',
            '{' => '}',
            '<' => '>',
            _ => throw new InvalidDataException("Unexpected input char " + inputChar)
        };
    }
}