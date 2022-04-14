// See https://adventofcode.com/2021/day/3

using System;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var diagnosticReport = File.ReadAllLines(@"C:\Data\dev\Spikes\AdventOfCode2021\AdventOfCode2021\Day03-Diagnostics\inputdata.txt");

        Console.WriteLine("Part 1: " + CalculatePart1(diagnosticReport));
        Console.WriteLine("Part 2: " + CalculatePart2(diagnosticReport));
    }

    public static int CalculatePart1(string[] diagnosticReport)
    {
        var numberOfBits = diagnosticReport[0].Length;
        var numberOfReadings = diagnosticReport.Length;
        var results = Flatten(GetNumberOfHighBits(diagnosticReport, numberOfBits), numberOfReadings);

        var gammaRate = 0;
        var epsilonRate = 0;
        for (var i = 0; i < numberOfBits; i++)
        {
            if (results[i] == 1)
                gammaRate += (int)Math.Pow(2, results.Length - 1 - i);
            else
                epsilonRate += (int)Math.Pow(2, results.Length - 1 - i);
        }

        return gammaRate * epsilonRate;
 }

    private static int[] GetNumberOfHighBits(string[] diagnosticReport, int numberOfBits)
    {
        int[] results = new int[numberOfBits];

        foreach (var number in diagnosticReport)
        {
            for (var i = 0; i < number.Length; i++)
            {
                var bit = number[i];
                if (bit == '1')
                    results[i] += 1;
            }
        }

        return results;
    }

    private static int[] Flatten(int[] numberOfHighBits, int numberOfReadings) => numberOfHighBits.Select(numberOfOnes => numberOfOnes >= (decimal)numberOfReadings / 2 ? 1 : 0).ToArray();

    public static int CalculatePart2(string[] diagnosticReport)
    {
        var oxygenResult = Rating(diagnosticReport, (a, b) => a == b);
        var oxygenRating = ConvertBinaryStringToInt(oxygenResult);

        var co2Result = Rating(diagnosticReport, (a, b) => a != b);
        var co2Rating = ConvertBinaryStringToInt(co2Result);

        return co2Rating * oxygenRating;
    }

    private static int ConvertBinaryStringToInt(string binaryString)
    {
        var results = 0;
        for (var i = 0; i < binaryString.Length; i++)
        {
            if (binaryString[i] == '1')
                results += (int)Math.Pow(2, binaryString.Length - 1 - i);
        }

        return results;
    }

    private static string Rating(string[] diagnosticReport, Func<string, string, bool> comparator, int index = 0)
    {
        var numberOfBits = diagnosticReport[0].Length;
        var numberOfReadings = diagnosticReport.Length;
        var mostCommonBits = Flatten(GetNumberOfHighBits(diagnosticReport, numberOfBits), numberOfReadings);

        var filtered = diagnosticReport.Where(x => comparator(x[index].ToString(), mostCommonBits[index].ToString())).ToArray();

        if (filtered.Length > 1)
            return Rating(filtered, comparator, index + 1);
        return filtered[0];
    }
}
