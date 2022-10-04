namespace Puzzles.Day17TrickShot;

public class Velocity
{
    public Velocity(int x, int y)
    {
        X = x;
        Y = y;
    }

    protected bool Equals(Velocity other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Velocity)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public int X { get; private set; }
    public int Y { get; private set; }

    public void DecrementTowardsZero()
    {
        if (X > 0)
            X = X - 1;
        else if (X < 0)
            X = X + 1;    
    }

    public void DecrementY()
    {
        Y = Y - 1;
    }
}