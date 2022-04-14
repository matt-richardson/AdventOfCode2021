using System.Reflection;

namespace Puzzles;

public static class Helpers
{
    public static string[] ReadInputData(string puzzle)
    {
        var assembly = Assembly.GetExecutingAssembly();

        using var stream = assembly.GetManifestResourceStream($"Puzzles.{puzzle}.inputdata.txt");
        using var reader = new StreamReader(stream!);
        var content = reader.ReadToEnd();
        var lines = content.Contains("\r\n")
            ? content.Split("\r\n")
            : content.Split('\r');
        return lines
            .Take(lines.Length - 1)
            .ToArray();
    }
}
