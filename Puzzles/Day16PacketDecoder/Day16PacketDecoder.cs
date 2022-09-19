
namespace Puzzles.Day16PacketDecoder;

public class Day16PacketDecoder : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day16PacketDecoder))[0];
        return CalculatePart1(input);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day16PacketDecoder))[0];
        return CalculatePart2(input);
    }

    private static long CalculatePart1(string input)
    {
        var result = PacketDecoder.DecodeHex(input);
        return result.SumOfVersionNumbers();
    }

    private static long CalculatePart2(string input)
    {
        var result = PacketDecoder.DecodeHex(input);
        return result.Value;
    }
}
