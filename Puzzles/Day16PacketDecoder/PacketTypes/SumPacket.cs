namespace Puzzles.Day16PacketDecoder.PacketTypes;

public class SumPacket : OperatorPacket
{
    public SumPacket(int version, string bitRepresentation) : base(0, version, bitRepresentation)
    {
    }

    public override long Value => SubPackets.Sum(x => x.Value);
}