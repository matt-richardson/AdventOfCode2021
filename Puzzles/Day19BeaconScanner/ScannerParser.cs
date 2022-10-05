namespace Tests;

public class ScannerParser
{
    public static ScannerMap Parse(string[] inputData)
    {
        var map = new ScannerMap();
        Scanner? scanner = null;
        foreach (var line in inputData)
        {
            if (line.StartsWith("---"))
            {
                scanner = new Scanner(line.TrimStart('-', ' ').TrimStart('-', ' '));
            }
            else if (string.IsNullOrEmpty(line))
            {
                if (scanner == null) throw new ArgumentNullException();
                map.AddScanner(scanner);
            }
            else
            {
                if (scanner == null) throw new ArgumentNullException();
                var coords = line.Split(',').Select(int.Parse).ToArray();
                scanner.AddBeacon(new Beacon(coords[0], coords[1], coords[2]));
            }
        }
        if (scanner == null) throw new ArgumentNullException();
        map.AddScanner(scanner);
        return map;
    }
}