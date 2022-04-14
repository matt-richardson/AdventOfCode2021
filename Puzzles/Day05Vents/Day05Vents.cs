// See https://adventofcode.com/2021/day/3

namespace Puzzles.Day05Vents;

public class Day05Vents : IPuzzle
{
    public (object answer1, object answer2) Calculate()
    {
        var diagnosticReport = Helpers.ReadInputData(nameof(Day05Vents));

        return (
            CalculatePart1(diagnosticReport),
            CalculatePart2(diagnosticReport)
        );
    }

    public static int CalculatePart1(string[] vents)
    {
        var map = new Map(vents);
        foreach (var vent in vents)
            map.AddVent(vent, Directions.HorizontalAndVertical);
//        Console.WriteLine(map);
        return map.NumberOfPointsWithAValueOfTwoOrHigher();
    }


    public static int CalculatePart2(string[] vents)
    {
        var map = new Map(vents);
        foreach (var vent in vents)
            map.AddVent(vent, Directions.HorizontalAndVerticalAndDiagonal);
        //Console.WriteLine(map);
        return map.NumberOfPointsWithAValueOfTwoOrHigher();
    }
}
