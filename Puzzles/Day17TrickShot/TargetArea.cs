using System.Text.RegularExpressions;

namespace Puzzles.Day17TrickShot;

public record TargetArea(int MinX, int MaxX, int MinY, int MaxY)
{
    /// <remarks>
    /// target area: x=20..30, y=-10..-5
    /// </remarks>
    /// <param name="input"></param>
    /// <returns></returns>
    public static TargetArea Parse(string input)
    {
        var regex = new Regex("target area: x=([-\\d]+)\\.\\.([-\\d]+), y=([-\\d]+)\\.\\.([-\\d]+)");
        var match = regex.Match(input);
        return new TargetArea(
            MinX: Convert.ToInt32(match.Groups[1].Value),
            MaxX: Convert.ToInt32(match.Groups[2].Value),
            MinY: Convert.ToInt32(match.Groups[3].Value),
            MaxY: Convert.ToInt32(match.Groups[4].Value)
        );
    }
    public bool IsInTargetArea(Probe probe) 
        => probe.Position.X >= MinX && probe.Position.X <= MaxX && probe.Position.Y >= MinY && probe.Position.Y <= MaxY;

    public bool HasOvershot(Probe probe)
        => probe.Position.X > MaxX || probe.Position.Y < MinY;
}