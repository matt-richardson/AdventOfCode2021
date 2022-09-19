namespace Puzzles.Day16PacketDecoder;

public abstract class Packet
{
    public abstract int TypeId { get;}
    public int Version { get; protected init; }
    public abstract string BitRepresentation { get; }
    public abstract long SumOfVersionNumbers();
    public abstract string UnusedBitRepresentation { get; }
}