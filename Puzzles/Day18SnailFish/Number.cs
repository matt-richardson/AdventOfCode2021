namespace Puzzles.Day18SnailFish;

public abstract class Number
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

            return new Pair(input[0], Parse(input[2..]));
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
    
    public static implicit operator Number((Number, Number) tuple) => new Pair(tuple.Item1, tuple.Item2);
    public static Number operator +(Number left, Number right)
    {
        var pair = new Pair(left.DeepClone(), right.DeepClone());
        var clone = pair;
        clone.Reduce();
        return clone;
    }

    public static implicit operator Number(char number) => new RegularNumber(number);
    public static implicit operator Number(int number) => new RegularNumber(number);

    public void SetParent(Number parent)
    {
        this.Parent = parent;
    }

    protected Number? Parent { get; private set; }

    public void Reduce()
    {
        var thingHappened = false;
        do
        {
            Console.WriteLine();
            Console.WriteLine(this);
            if (this is Pair pair)
            {
                thingHappened = pair.Explode() || pair.Split();
            }
        } while (thingHappened);
    }

    public static Number Add(IEnumerable<Number> numbers)
    {
        var numbersArray = numbers as Number[] ?? numbers.ToArray();
        var first = numbersArray.First();
        return numbersArray.Skip(1).Aggregate(first, (accum, second) =>
        {
            Console.WriteLine("  " + accum);
            Console.WriteLine("+ " + second);
            var number = accum + second;
            Console.WriteLine("= " + number);
            Console.WriteLine();
            return number;
        });
    }

    public abstract Number DeepClone();
    public abstract int Magnitude();
}