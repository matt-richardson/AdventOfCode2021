using System.Text;

namespace Puzzles.Day05Vents;

public class Map
{
    private readonly int[,] data;

    public Map(string[] vents)
    {
        var parsedCoordinates = ParseVents(vents).ToArray();
        var maxX = Math.Max(parsedCoordinates.OrderByDescending(x => x.x1).First().x1, parsedCoordinates.OrderByDescending(x => x.x2).First().x2);
        var maxY = Math.Max(parsedCoordinates.OrderByDescending(x => x.y1).First().y1, parsedCoordinates.OrderByDescending(x => x.y2).First().y2);
        data = new int[maxX+1, maxY+1];
    }

    private static IEnumerable<(int x1, int y1, int x2, int y2)> ParseVents(string[] vents)
    {
        foreach (var line in vents)
        {
            var pairs = line.Split(" -> ");
            var from = pairs[0].Split(",");
            var to = pairs[1].Split(",");
            yield return (int.Parse(from[0]), int.Parse(from[1]), int.Parse(to[0]), int.Parse(to[1]));
        }
    }

    public void AddVent(string vent, Directions directions)
    {
        var parsed = ParseVents(new [] {vent}).First();

        if (parsed.x1 == parsed.x2)
        {
            var min = Math.Min(parsed.y1, parsed.y2);
            var max = Math.Max(parsed.y1, parsed.y2);
            for (var i = min; i <= max; i++)
                data[parsed.x1, i] = data[parsed.x1, i] + 1;
        }
        else if (parsed.y1 == parsed.y2)
        {
            var min = Math.Min(parsed.x1, parsed.x2);
            var max = Math.Max(parsed.x1, parsed.x2);
            for (var i = min; i <= max; i++)
                data[i, parsed.y1] = data[i, parsed.y1] + 1;
        }
        else if (directions == Directions.HorizontalAndVerticalAndDiagonal)
        {
            var minX = Math.Min(parsed.x1, parsed.x2);
            var maxX = Math.Max(parsed.x1, parsed.x2);
            var y = parsed.y1;
            var x = parsed.x1;
            for (var i = minX; i <= maxX; i++)
            {
                data[x, y] = data[x, y] + 1;
                y = IncrementY(parsed, y);
                x = IncrementX(parsed, x);
            }
        }
    }

    private static int IncrementX((int x1, int y1, int x2, int y2) parsed, int i) => parsed.x1 > parsed.x2 ? i - 1 : i + 1;

    private static int IncrementY((int x1, int y1, int x2, int y2) parsed, int i) => parsed.y1 > parsed.y2 ? i - 1 : i + 1;

    public int NumberOfPointsWithAValueOfTwoOrHigher()
    {
        var count = 0;
        for  (var x = data.GetLowerBound(0); x <= data.GetUpperBound(0); x++)
        {
            for (var y = data.GetLowerBound(1); y <= data.GetUpperBound(1); y++)
            {
                if (data[x, y] >= 2)
                    count++;
            }
        }

        return count;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var y = data.GetLowerBound(1); y <= data.GetUpperBound(1); y++)
        {
            for  (var x = data.GetLowerBound(0); x <= data.GetUpperBound(0); x++)
            {
                if (data[x, y] == 0)
                    sb.Append('.');
                else
                    sb.Append(data[x, y]);
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}

public enum Directions
{
    HorizontalAndVertical,
    HorizontalAndVerticalAndDiagonal,
}