namespace Puzzles.Day16PacketDecoder.PacketTypes;

public class ProductPacket : OperatorPacket
{
    public ProductPacket(int version, string bitRepresentation) : base(1, version, bitRepresentation)
    {
    }

    public override long Value =>  SubPackets.Skip(1).Aggregate(SubPackets.First().Value, (i, packet) => i * packet.Value);
}