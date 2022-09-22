namespace Puzzles.Day17TrickShot;

public class Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Position(Position position)
    {
        X = position.X;
        Y = position.Y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }

    public void Increment(Velocity velocity)
    {
        X = X + velocity.X;
        Y = Y + velocity.Y;
    }
}