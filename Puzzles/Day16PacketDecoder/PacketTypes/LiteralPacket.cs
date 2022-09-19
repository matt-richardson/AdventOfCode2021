namespace Puzzles.Day16PacketDecoder.PacketTypes;

public class LiteralPacket : Packet
{
    public LiteralPacket(int version, string bits)
    {
        Version = version;
        var bitRepresentation = bits[..6];

        var valueRepresentation = "";
        for (var i = 6; i < bits.Length - 4; i += 5)
        {
            var isLastPacket = bits[i] == '0';
            var val = bits[(i+1)..(i + 5)];
            bitRepresentation += bits[i..(i + 5)];
            valueRepresentation += val;
            if (isLastPacket)
                break;
        }
        Value = Convert.ToInt64(valueRepresentation, 2);
        BitRepresentation = bitRepresentation;
        UnusedBitRepresentation = bits[(bitRepresentation.Length)..bits.Length];
    }
    
    public override int TypeId => 4;
    public override string BitRepresentation { get; }
    public override long SumOfVersionNumbers() => Version;
    public override string UnusedBitRepresentation { get; }

    public override long Value { get; }
}