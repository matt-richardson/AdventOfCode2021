using System.Reflection;

namespace Puzzles;

public static class Helpers
{
    public static string[] ReadInputData(string puzzle)
    {
        var assembly = Assembly.GetExecutingAssembly();

        using var stream = assembly.GetManifestResourceStream($"Puzzles.{puzzle}.inputdata.txt");
        using var reader = new StreamReader(stream!);

        //use the same approach as File.ReadAllLines()
        var lines = new List<string>();
        string? line;
        using (var sr = new StreamReader(stream!))
            while ((line = sr.ReadLine()) != null)
                lines.Add(line);

        return lines.ToArray();
    }
}
