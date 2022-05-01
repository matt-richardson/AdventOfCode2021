using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Puzzles.Day09LavaTubes;

public static class Day09LavaTubesExtensionMethods
{
    public static Point? PointAtCoordinate(this IList<Point> data, int row, int col)
    {
        return data.FirstOrDefault(point => point.RowNumber == row && point.ColNumber == col);
    }
    
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> data, Func<IList<T>, T, T> func)
    {
        var enumeratedList = data.ToList();
        foreach (var item in enumeratedList)
            yield return func(enumeratedList, item); 
    }

    public static IEnumerable<(int index, T? previous, T current, T? next)> Sandwich<T>(this IEnumerable<T> data)
    {
        return data.ToArray().Sandwich();
    }
    
    [return: NotNull]
    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> data)
    {
        return data.Where(x => x != null)!;
    }

    public static int Product<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
        return source.Select(selector).Aggregate((accumulator, current) => accumulator * current);
    }
    
    public static IEnumerable<(int index, T? previous, T current, T? next)> Sandwich<T>(this T[] data) 
    {
        var lowerBound = data.GetLowerBound(0);
        var upperBound = data.GetUpperBound(0);
        for (var index = lowerBound; index <= upperBound; index++)
        {
            var previous = index == lowerBound ? default : data[index - 1];
            var current = data[index];
            var next = index == upperBound ? default : data[index + 1];
            yield return (index, previous, current, next);
        }
    }

    public static int[] Parse(this string input)
    {
        return input.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
    }
}
