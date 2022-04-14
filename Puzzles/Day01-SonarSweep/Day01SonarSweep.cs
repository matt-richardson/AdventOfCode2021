// See https://adventofcode.com/2021/day/

namespace Puzzles.Day01_SonarSweep;

public class Day01SonarSweep
{
    public Day01SonarSweep()
    {
        var sonarReadings = File.ReadAllLines(@"/Users/matt/dev/Spikes/AdventOfCode2021/AdventOfCode2021/Puzzles/Day01-SonarSweep/inputdata.txt");

        Console.WriteLine("Part 1: " + CalculatePart1(sonarReadings));
        Console.WriteLine("Part 2: " + CalculatePart2(sonarReadings));
    }

    public static int CalculatePart1(string[] readings)
    {
        var lastValue = -1;
        var i = 0;
        foreach (var reading in readings)
        {
            var currentValue = int.Parse(reading);
            if (currentValue > lastValue && lastValue != -1)
                i++;
            lastValue = currentValue;
        }

        return i;
    }

    public static int CalculatePart2(string[] readings)
    {
        var lastValue = -1;
        var i = 0;
        for (var index = 0; index < readings.Length - 2; index++)
        {
            var currentValue = int.Parse(readings[index]) + int.Parse(readings[index + 1]) + int.Parse(readings[index + 2]);
            if (currentValue > lastValue && lastValue != -1)
                i++;
            lastValue = currentValue;
        }

        return i;
    }
}
