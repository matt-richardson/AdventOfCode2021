namespace Puzzles.Day16PacketDecoder.PacketTypes;

public class GreaterThanPacket : OperatorPacket
{
    public GreaterThanPacket(int version, string bitRepresentation) : base(5, version, bitRepresentation)
    {
    }

    public override long Value => SubPackets.First().Value > SubPackets.Last().Value ? 1 : 0;
}