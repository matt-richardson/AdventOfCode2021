// See https://adventofcode.com/2021/day/3

namespace Puzzles.Day06_Lanternfish;

public class Day06LanternFish
{
    public Day06LanternFish()
    {
        var input = File.ReadAllLines(@"C:\Data\dev\Spikes\AdventOfCode2021\AdventOfCode2021\Day06-Lanternfish\inputdata.txt")[0];

        Console.WriteLine("Part 1: " + CalculatePart1(input, 80));
        Console.WriteLine("Part 2: " + CalculatePart2(input, 256));
    }

    public static long CalculatePart1(string input, int days)
    {
        var internalFishTimers = input.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        var lanternFishSchool = new LanternFishSchool(internalFishTimers);

        for(var i = 0; i < days; i++)
        {
            lanternFishSchool.DayPassed();
            Console.WriteLine($"After {(i + 1)} days: {lanternFishSchool}");
        }

        return lanternFishSchool.Count;
    }

    public static long CalculatePart2(string input, int days)
    {
        return CalculatePart1(input, days);
    }
}
