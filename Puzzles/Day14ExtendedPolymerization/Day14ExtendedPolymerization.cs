namespace Puzzles.Day14ExtendedPolymerization;

public class Day14ExtendedPolymerization
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day14ExtendedPolymerization));
       
        return CalculatePart1(input);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day14ExtendedPolymerization));
        return CalculatePart2(input);
    }
    
    public static long CalculatePart1(string[] input)
    {
        var instructions = new PolymerInstructions(input);

        var result = instructions.Template.Apply(instructions.Rules, 10);

        return result.CountOfMostCommonElement - result.CountOfLeastCommonElement;
    }

    public static string CalculatePart2(string[] input)
    {
        var instructions = new PolymerInstructions(input);

        throw new NotImplementedException();
    }
}
