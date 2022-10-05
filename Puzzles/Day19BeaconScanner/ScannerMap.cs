namespace Tests;

public class ScannerMap
{
    public IList<Scanner> Scanners = new List<Scanner>();
    
    public void AddScanner(Scanner scanner)
    {
        scanner.CalculateBeaconDeltas();
        Scanners.Add(scanner);
    }
}