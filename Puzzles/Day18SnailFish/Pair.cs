namespace Puzzles.Day18SnailFish;

public class Pair : Number
{
    protected bool Equals(Pair other)
    {
        return Left.Equals(other.Left) && Right.Equals(other.Right);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Pair)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Left, Right);
    }

    public Pair(Number left, Number right)
    {
        Left = left;
        Right = right;
    }

    public Number Left { get; }
    public Number Right { get; }
    
    public override string ToString() => $"[{Left},{Right}]";
}