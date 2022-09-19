namespace Puzzles.Day16PacketDecoder.PacketTypes;

public class EqualToPacket : OperatorPacket
{
    public EqualToPacket(int version, string bitRepresentation) : base(6, version, bitRepresentation)
    {
    }

    public override long Value => SubPackets.First().Value == SubPackets.Last().Value ? 1 : 0;
}