namespace Puzzles.Day16PacketDecoder.PacketTypes;

public class MaximumPacket : OperatorPacket
{
    public MaximumPacket(int version, string bitRepresentation) : base(3, version, bitRepresentation)
    {
    }

    public override long Value => SubPackets.Max(x => x.Value);
}