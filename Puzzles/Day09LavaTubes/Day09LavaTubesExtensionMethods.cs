using System.Diagnostics;

namespace Puzzles.Day09LavaTubes;

public static class Day09LavaTubesExtensionMethods
{
    public static IEnumerable<Point> Parse(this string[] input)
    {
        var data = input.Select(Parse).ToArray();
     
        var rowLowerBound = data.GetLowerBound(0);
        var rowUpperBound = data.GetUpperBound(0);
        var colLowerBound = data[rowLowerBound].GetLowerBound(0);
        var colUpperBound = data[rowLowerBound].GetUpperBound(0);
        for (var rowNumber = rowLowerBound; rowNumber < rowUpperBound; rowNumber++)
        {
            var rowUp = rowNumber == rowLowerBound ? null : data[rowNumber - 1];
            var rowCurrent = data[rowNumber];
            var rowDown = rowNumber == rowUpperBound - 1 ? null : data[rowNumber + 1];
            for (var colNumber = colLowerBound; colNumber < colUpperBound; colNumber++)
            {
                yield return Point(rowNumber, colNumber, rowCurrent, rowUp, rowDown, colLowerBound, colUpperBound);
            }
        }
    }
    
    private static Point Point(int rowNumber, int colNumber, int[] rowCurrent, int[] rowUp, int[] rowDown, int colLowerBound, int colUpperBound)
    {
        return new Point(
            rowNumber,
            colNumber,
            rowCurrent[colNumber],
            rowUp?[colNumber],
            rowDown?[colNumber],
            colNumber == colLowerBound ? null : rowCurrent[colNumber - 1],
            colNumber == colUpperBound - 1 ? null : rowCurrent[colNumber + 1]
        );
    }
    
    static IEnumerable<(int, T?, T, T?)> Loop<T>(this T[] data) 
    {
        var lowerBound = data.GetLowerBound(0);
        var upperBound = data.GetUpperBound(0);
        for (var index = lowerBound; index < upperBound; index++)
        {
            var previous = index == lowerBound ? default : data[index - 1];
            var current = data[index];
            var next = index == upperBound - 1 ? default : data[index + 1];
            yield return (index, previous, current, next);
        }
    }

    public static int[] Parse(this string input)
    {
        return input.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
    }
}

[DebuggerDisplay("({RowNumber},{ColNumber}): Height {Height}, Risk {RiskLevel}")]
public record Point(int RowNumber, int ColNumber, int Height, int? Up, int? Down, int? Left, int? Right)
{
    public bool IsLowPoint =>
        IsLowerThanPointUp &&
        IsLowerThanPointDown &&
        IsLowerThanPointLeft &&
        IsLowerThanPointRight;

    public int RiskLevel => Height + 1;

    private bool IsLowerThanPointUp => Up == null || Up > Height;
    private bool IsLowerThanPointDown => Down == null || Down > Height;
    private bool IsLowerThanPointLeft => Left == null || Left > Height;
    private bool IsLowerThanPointRight => Right == null || Right > Height;
};

