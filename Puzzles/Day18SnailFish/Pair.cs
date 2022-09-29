namespace Puzzles.Day18SnailFish;

public class Pair : Number
{
    #region Equality
    private bool Equals(Pair other)
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
    #endregion

    public Pair(Number left, Number right)
    {
        Left = left;
        Right = right;
        Left.SetParent(this);
        Right.SetParent(this);
    }

    private Number Left { get; set; }
    private Number Right { get; set; }
    
    public override string ToString() => $"[{Left},{Right}]";

    public bool Explode() => Explode(0);

    private bool Explode(int depth)
    {
        //this is a bit more "inspired" by https://topaz.github.io/paste/#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
        //than I'd like to admit. I was tired.
        if (Left is Pair left && left.Explode(depth + 1)) return true;
        if (Right is Pair right && right.Explode(depth + 1)) return true;

        if (depth != 4) 
            return false;
        //Console.WriteLine($"Exploding pair {this}");
        var leftNumber = ((Pair?)Parent)?.FindLeftNumber(this);
        var rightNumber = ((Pair?)Parent)?.FindRightNumber(this);

        // if (leftNumber != null) 
        //     Console.WriteLine($"Adding {Left} to left number {leftNumber}");
        // else
        //     Console.WriteLine($"No left value to add {Left} to");
        // if (rightNumber != null) 
        //     Console.WriteLine($"Adding {Right} to right number {rightNumber} ");
        // else
        //     Console.WriteLine($"No right value to add {Right} to");
        leftNumber?.Add((RegularNumber) Left);
        rightNumber?.Add((RegularNumber) Right);

        //Console.WriteLine($"Replacing pair {this} with 0");
        ((Pair?)Parent)!.ReplaceWith(this, new RegularNumber(0));
        return true;
    }
    
    public bool Split()
    {
        if (Left is RegularNumber leftNumber && leftNumber.Split()) return true;
        if (Left is Pair left && left.Split()) return true;
        //arrgh. this caused lots of pain... the line above and the line below were swapped
        //meaning the answers were wrong because it was calculating in the wrong order.
        if (Right is RegularNumber rightNumber && rightNumber.Split()) return true;
        if (Right is Pair right && right.Split()) return true;
        return false;
    }

    internal void ReplaceWith(Number caller, Number replacement)
    {
        replacement.SetParent(this);
        if (ReferenceEquals(Left, caller)) Left = replacement;
        if (ReferenceEquals(Right, caller)) Right = replacement;
    }

    private RegularNumber? FindLeftNumber(Pair caller)
    {
        if (ReferenceEquals(Left, caller))
            return ((Pair?)Parent)?.FindLeftNumber(this);

        if (Left is RegularNumber left)
            return left;

        return ((Pair) Left).RightLeaf();
    }

    private RegularNumber RightLeaf()
    {
        if (Right is RegularNumber right)
            return right;
        return ((Pair) Right).RightLeaf();
    }
    
    private RegularNumber LeftLeaf()
    {
        if (Left is RegularNumber left)
            return left;
        return ((Pair) Left).LeftLeaf();
    }

    private RegularNumber? FindRightNumber(Pair caller)
    {
        if (ReferenceEquals(Right, caller))
            return ((Pair?)Parent)?.FindRightNumber(this);

        if (Right is RegularNumber right)
            return right;

        return ((Pair) Right).LeftLeaf();
    }

    public override Number DeepClone() => new Pair(Left.DeepClone(), Right.DeepClone());
    public override int Magnitude() => Left.Magnitude() * 3 + Right.Magnitude() * 2;
}