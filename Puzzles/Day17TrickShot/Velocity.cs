namespace Puzzles.Day17TrickShot;

public class Velocity
{
    public Velocity(int x, int y)
    {
        X = x;
        Y = y;
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