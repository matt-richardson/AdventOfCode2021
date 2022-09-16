
namespace Puzzles.Day15Chiton;

public class Day15Chiton : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day15Chiton));
        return CalculatePart1(input);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day15Chiton));
        return CalculatePart2(input);
    }

    public static long CalculatePart1(string[] input)
    {
        var riskMap = new RiskMap(input);
        var lowestRiskPath = riskMap.CalculateLowestRiskPath();
        return lowestRiskPath;
    }

    public static string CalculatePart2(string[] input)
    {
        throw new NotImplementedException();
    }
}
