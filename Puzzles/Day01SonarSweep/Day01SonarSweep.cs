// See https://adventofcode.com/2021/day/

namespace Puzzles.Day01SonarSweep;

public class Day01SonarSweep : IPuzzle
{
    public object CalculatePart1()
    {
        var sonarReadings = Helpers.ReadInputData(nameof(Day01SonarSweep));
        return CalculatePart1(sonarReadings);
    }

    public object CalculatePart2()
    {
        var sonarReadings = Helpers.ReadInputData(nameof(Day01SonarSweep));
        return CalculatePart2(sonarReadings);
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
