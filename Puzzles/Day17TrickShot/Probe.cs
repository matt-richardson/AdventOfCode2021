namespace Puzzles.Day17TrickShot;

public class Probe
{
    public readonly Position Position = new(0, 0);
    private readonly Velocity velocity;

    public Probe(Velocity velocity)
    {
        this.velocity = velocity;
        this.InitialVelocity = new Velocity(velocity.X, velocity.Y);
    }

    public Velocity InitialVelocity { get; }

    public int MaxYPosition { get; private set; }

    public void Step()
    {
        Position.Increment(velocity);
        velocity.DecrementTowardsZero();
        velocity.DecrementY();

        if (Position.Y > MaxYPosition)
            MaxYPosition = Position.Y;
    }
}