namespace Puzzles.Day16PacketDecoder.PacketTypes;

public class MinimumPacket : OperatorPacket
{
    public MinimumPacket(int version, string bitRepresentation) : base(2, version, bitRepresentation)
    {
    }

    public override long Value => SubPackets.Min(x => x.Value);
}