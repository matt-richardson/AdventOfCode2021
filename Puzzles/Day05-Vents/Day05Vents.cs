// See https://adventofcode.com/2021/day/3

namespace Puzzles.Day05_Vents;

public class Day05Vents
{
    public Day05Vents()
    {
        var diagnosticReport = File.ReadAllLines(@"C:\Data\dev\Spikes\AdventOfCode2021\AdventOfCode2021\Day05-Vents\inputdata.txt");

        Console.WriteLine("Part 1: " + CalculatePart1(diagnosticReport));
        Console.WriteLine("Part 2: " + CalculatePart2(diagnosticReport));
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
