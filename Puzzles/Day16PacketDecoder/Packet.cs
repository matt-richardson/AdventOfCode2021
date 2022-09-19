namespace Puzzles.Day16PacketDecoder;

public abstract class Packet
{
    public abstract int TypeId { get;}
    public int Version { get; protected init; }
    public string BitRepresentation { get; protected init; }
    public abstract long SumOfVersionNumbers();
    public string UnusedBitRepresentation { get; protected init; }
}