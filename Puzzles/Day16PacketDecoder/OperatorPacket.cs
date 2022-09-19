namespace Puzzles.Day16PacketDecoder;

public class OperatorPacket : Packet
{
    public OperatorPacket(int packetTypeId, int version, string bits)
    {
        TypeId = packetTypeId;
        Version = version;
        BitRepresentation = bits;
        LengthTypeId = Convert.ToInt32(bits[6..7], 2);
        BitRepresentation = bits;
        UnusedBitRepresentation = LengthTypeId switch
        {
            0 => GetSubPacketsBySubPacketLength(bits),
            1 => GetSubPacketsBySubPacketCount(bits),
            _ => string.Empty
        };
    }

    private string GetSubPacketsBySubPacketCount(string bits)
    {
        var subPacketsCount = Convert.ToInt32(bits[7..18], 2);
        var subPacketRepresentation = bits[18..];
        for (var i = 0; i < subPacketsCount; i++)
        {
            var packet = PacketDecoder.DecodeBits(subPacketRepresentation);
            SubPackets.Add(packet);
            subPacketRepresentation = packet.UnusedBitRepresentation ?? throw new ArgumentNullException();
        }

        return subPacketRepresentation;
    }

    private string GetSubPacketsBySubPacketLength(string bits)
    {
        var subPacketsLength = Convert.ToInt32(bits[7..22], 2);
        var subPacketRepresentation = bits[22..(22 + subPacketsLength)];
        do
        {
            var packet = PacketDecoder.DecodeBits(subPacketRepresentation);
            SubPackets.Add(packet);
            subPacketRepresentation = packet.UnusedBitRepresentation;
        } while (subPacketRepresentation.Length > 0);

        return bits[(22 + subPacketsLength)..];
    }

    public override int TypeId { get; }
    public override string BitRepresentation { get; }
    public override long SumOfVersionNumbers() => SubPackets.Aggregate((long)Version, (accum, packet) => accum + packet.SumOfVersionNumbers());
    public override string UnusedBitRepresentation { get; }
    public int LengthTypeId { get; }
    public List<Packet> SubPackets { get; } = new();
}