namespace Puzzles.Day18SnailFish;

public class Number
{
    public static Number Parse(string input)
    {
        if (input[0] == '[')
        {
            var number = GetExpressionWithinBrackets(input);
            if (input.Length <= number.Length + 2) 
                return Parse(number);
            
            var right = input[(3 + number.Length)..];
            return new Pair(Parse(number), Parse(right));
        }

        if (char.IsDigit(input[0]))
        {
            if (!input.Contains(','))
                return new RegularNumber(input[0]);

            return (input[0], Parse(input[2..]));
        }

        throw new ArgumentException();
    }

    private static string GetExpressionWithinBrackets(string input)
    {
        var openBracketCount = 1;
        var position = 0;
        do
        {
            position++;
            if (input[position] == '[')
                openBracketCount++;
            if (input[position] == ']')
                openBracketCount--;
        } while (openBracketCount > 0);

        var number = input[1..position];
        return number;
    }

    public static implicit operator Number(int number) => new RegularNumber(number);

    public static implicit operator Number(char number) => new RegularNumber(number);

    public static implicit operator Number((Number, Number) tuple) => new Pair(tuple.Item1, tuple.Item2);
}