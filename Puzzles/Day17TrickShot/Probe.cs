namespace Puzzles.Day17TrickShot;

public class Probe
{
    public readonly Position Position = new(0, 0);
    private readonly Velocity velocity;
    private readonly List<Position> positions = new();

    public Probe(Velocity velocity)
    {
        this.velocity = velocity;
        this.InitialVelocity = velocity;
    }

    public Velocity InitialVelocity { get; }

    public int MaxYPosition => positions.MaxBy(position => position.Y)!.Y;

    public void Step()
    {
        Position.Increment(velocity);
        velocity.DecrementTowardsZero();
        velocity.DecrementY();

        positions.Add(new Position(Position));
    }
}