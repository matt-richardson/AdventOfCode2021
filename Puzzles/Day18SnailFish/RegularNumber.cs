namespace Puzzles.Day18SnailFish;

public class RegularNumber : Number
{
    protected bool Equals(RegularNumber other)
    {
        return Number == other.Number;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((RegularNumber)obj);
    }

    public override int GetHashCode() => Number;

    private int Number { get; set; }

    public RegularNumber(int number)
    {
        Number = number;
    }
    
    public RegularNumber(char number)
    {
        Number = int.Parse(number.ToString());
    }

    public override string ToString() => Number.ToString();

    public void Add(RegularNumber regularNumber)
    {
        Number = Number + regularNumber.Number;
    }

    public bool Split()
    {
        if (!TrySplit(this, out var replacement)) 
            return false;
        if (Parent is Pair parent)
            parent.ReplaceWith(this, replacement!);
        return true;
    }

    public static bool TrySplit(RegularNumber number, out Pair? replacement)
    {
        if (number.Number < 10)
        {
            replacement = null;
            return false;
        }

        var left = (int)Math.Round((double)number.Number / 2, MidpointRounding.ToZero);
        var right = (int)Math.Round((double)number.Number / 2, MidpointRounding.AwayFromZero);
        replacement = new Pair(left, right);
        return true;
    }
}