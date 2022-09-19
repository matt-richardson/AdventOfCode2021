using System.Text;
using Puzzles.Day16PacketDecoder.PacketTypes;

namespace Puzzles.Day16PacketDecoder;

public static class PacketDecoder
{
    public static Packet DecodeHex(string input)
    {
        var bits = new StringBuilder();
        foreach (var c in input)
            bits.Append(c.ParseToBits());
        return DecodeBits(bits.ToString());
    }
    
    public static Packet DecodeBits(string bits)
    {
        var bitRepresentation = bits;
        var version = Convert.ToInt32(bitRepresentation[..3], 2);
        var packetTypeId = Convert.ToInt32(bitRepresentation[3..6], 2);
        //could load via strategy or factory here, but... not worth the time.
        return packetTypeId switch
        {
            0 => new SumPacket(version, bitRepresentation),
            1 => new ProductPacket(version, bitRepresentation),
            2 => new MinimumPacket(version, bitRepresentation),
            3 => new MaximumPacket(version, bitRepresentation),
            4 => new LiteralPacket(version, bitRepresentation),
            5 => new GreaterThanPacket(version, bitRepresentation),
            6 => new LessThanPacket(version, bitRepresentation),
            7 => new EqualToPacket(version, bitRepresentation),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}