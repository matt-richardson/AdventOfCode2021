namespace Puzzles.Day11DumboOctopus;

public static class Day11DumboOctopusExtensionMethods
{
    public static Octopus? OctopusAtCoordinate(this IList<Octopus> data, int row, int col)
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
        var data = source.Cast<T?>().ToArray();
        var previous = new T?[] { default }.Concat(data);
        var next = data.Skip(1).Concat(new T?[] { default });
        return previous.Zip(data, next)
            .Select((x, index) => (index, x.First, x.Second!, x.Third));
    }
    
    public static int[] Parse(this string input)
    {
        return input.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
    }
}
