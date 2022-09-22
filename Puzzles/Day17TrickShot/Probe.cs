namespace Puzzles.Day17TrickShot;

public class Probe
{
    private int x = 0;
    private int y = 0;
    private Velocity velocity;
    private List<(int X, int Y)> positions = new();

    public Probe(Velocity velocity)
    {
        this.velocity = velocity;
        this.InitialVelocity = velocity;
    }

    public Velocity InitialVelocity { get; }

    public int MaxYPosition => positions.MaxBy(position => position.Y).Y;

    public void Step()
    {
        x = x + velocity.X;
        y = y + velocity.Y;
        velocity = velocity.X switch
        {
            > 0 => velocity with { X = velocity.X - 1 },
            < 0 => velocity with { X = velocity.X + 1 },
            _ => velocity
        };
        velocity = velocity with { Y = velocity.Y - 1 };
        positions.Add((x, y));
    }

    public bool IsInTargetArea(int minX, int maxX, int minY, int maxY) 
        => x >= minX && x <= maxX && y >= minY && y <= maxY;

    public bool HasOvershot(int minX, int maxX, int minY, int maxY)
        => x > maxX || y < minY;
}