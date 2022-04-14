// See https://adventofcode.com/2021/day/2

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        var plannedCourse =
            File.ReadAllLines(@"C:\Data\dev\Spikes\AdventOfCode2021\AdventOfCode2021\Day02-Piloting\inputdata.txt");

        Console.WriteLine("Part 1: " + CalculatePart1(plannedCourse));
        Console.WriteLine("Part 2: " + CalculatePart2(plannedCourse));
    }

    public static int CalculatePart1(string[] plannedCourse)
    {
        var position = new Position();

        foreach (var step in plannedCourse)
        {
            var (amount, direction) = Parse(step);

            switch (direction)
            {
                case Direction.Forward:
                    position.MoveForward(amount);
                    break;
                case Direction.Down:
                    position.MoveDown(amount);
                    break;
                case Direction.Up:
                    position.MoveUp(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unexpected value " + direction);
            }
        }

        return position.HorizontalPosition * position.Depth;
    }

    private static (int amount, Direction direction) Parse(string step)
    {
        var splitParts = step.Split(" ");
        var direction = splitParts[0];
        return (int.Parse(splitParts[1]), Enum.Parse<Direction>(direction, ignoreCase: true));
    }

    public static int CalculatePart2(string[] plannedCourse)
    {
        var horizontalPosition = 0;
        var depth = 0;
        var aim = 0;

        foreach (var step in plannedCourse)
        {
            var (amount, direction) = Parse(step);

            switch (direction)
            {
                case Direction.Forward:
                    horizontalPosition += amount;
                    depth += (aim * amount);
                    break;
                case Direction.Down:
                    aim += amount;
                    break;
                case Direction.Up:
                    aim -= amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unexpected value " + direction);
            }
        }

        return horizontalPosition * depth;
    }

    class Position
    {
        public int HorizontalPosition { get; private set; }
        public int Depth { get; private set; }
        public void MoveForward(int amount) => HorizontalPosition += amount;
        public void MoveDown(int amount) => Depth += amount;
        public void MoveUp(int amount) => Depth -= amount;
    }

    enum Direction
    {
        Forward,
        Down,
        Up
    }
}
