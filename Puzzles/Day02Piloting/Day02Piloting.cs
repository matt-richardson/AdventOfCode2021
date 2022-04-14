// See https://adventofcode.com/2021/day/2

using Puzzles.Day01SonarSweep;

namespace Puzzles.Day02Piloting;

public class Day02Piloting : IPuzzle
{
    public (object answer1, object answer2) Calculate()
    {
        var plannedCourse = Helpers.ReadInputData(nameof(Day02Piloting));

        return (
            CalculatePart1(plannedCourse),
            CalculatePart2(plannedCourse)
            );
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
