// See https://adventofcode.com/2021/day/3

namespace Puzzles.Day06LanternFish;

public class Day06LanternFish : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day06LanternFish)).First();
        return CalculatePart1(input, 80);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day06LanternFish)).First();
        return CalculatePart2(input, 256);
    }

    public static long CalculatePart1(string input, int days)
    {
        var internalFishTimers = input.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        var lanternFishSchool = new LanternFishSchool(internalFishTimers);

        for(var i = 0; i < days; i++)
        {
            lanternFishSchool.DayPassed();
            //Console.WriteLine($"After {(i + 1)} days: {lanternFishSchool}");
        }

        return lanternFishSchool.Count;
    }

    public static long CalculatePart2(string input, int days)
    {
        return CalculatePart1(input, days);
    }
}
