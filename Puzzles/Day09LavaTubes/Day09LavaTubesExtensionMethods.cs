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

    public static IEnumerable<(int index, T? previous, T current, T? next)> Sandwich<T>(this IEnumerable<T> source)
    {
        var data = source.ToArray();
        var previous = new T?[] { default }.Concat(data);
        var next = data.Skip(1).Concat(new T?[] { default });
        return previous.Zip(data, next)
            .Select((x, index) => (index, x.First, x.Second, x.Third));
    }
    
    public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> data)
    {
        return data.Where(x => x != null)!;
    }

    public static int Product<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
        return source.Select(selector).Aggregate((accumulator, current) => accumulator * current);
    }

    public static int[] Parse(this string input)
    {
        return input.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
    }
}
