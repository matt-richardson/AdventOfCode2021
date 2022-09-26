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
}