using System.Text;

namespace Puzzles.Day16PacketDecoder;

public static class PacketDecoder
{
    public static Packet DecodeHex(string input)
    {
        var bits = new StringBuilder();
        foreach (var c in input)
            bits.Append(ParseToBits(c));
        return DecodeBits(bits.ToString());
    }
    
    public static Packet DecodeBits(string bits)
    {
        var bitRepresentation = bits;
        var version = Convert.ToInt32(bitRepresentation[..3], 2);
        var packetTypeId = Convert.ToInt32(bitRepresentation[3..6], 2);
        switch (packetTypeId)
        {
            case 4:
                return new LiteralPacket(version, bitRepresentation);
            default:
                return new OperatorPacket(packetTypeId, version, bitRepresentation);
        }
    }

    private static string ParseToBits(char c)
    {
        switch (c)
        {
            case '0': return "0000";
            case '1': return "0001";
            case '2': return "0010";
            case '3': return "0011";
            case '4': return "0100";
            case '5': return "0101";
            case '6': return "0110";
            case '7': return "0111";
            case '8': return "1000";
            case '9': return "1001";
            case 'A': return "1010";
            case 'B': return "1011";
            case 'C': return "1100";
            case 'D': return "1101";
            case 'E': return "1110";
            case 'F': return "1111";
        }

        throw new ArgumentOutOfRangeException(nameof(c));
    }
}