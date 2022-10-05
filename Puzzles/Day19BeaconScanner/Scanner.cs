namespace Tests;

public class Scanner
{
    public string Name { get; }
    public IList<Beacon> Beacons = new List<Beacon>();
    private readonly Dictionary<(Beacon, Beacon), (int deltaX, int deltaY, int deltaZ)> deltas = new();
    public Scanner(string name)
    {
        Name = name;
    }

    public void AddBeacon(Beacon beacon)
    {
        Beacons.Add(beacon);
    }

    public void CalculateBeaconDeltas()
    {
        foreach (var beacon1 in Beacons)
        foreach (var beacon2 in Beacons.Where(x => beacon1 != x))
        {
            deltas.Add((beacon1, beacon2),
                (beacon1.X - beacon2.X, beacon1.Y - beacon2.Y, beacon1.Y - beacon2.Y));
        }
    }

    public bool OverlapsWith(Scanner other, int numberOfBeaconsToMatch)
    {
        var count = other.deltas
            .Count(x => deltas.Any(
                y =>
                    y.Value.deltaX == x.Value.deltaX &&
                    y.Value.deltaY == x.Value.deltaY &&
                    y.Value.deltaZ == x.Value.deltaZ
            ));
        return count > numberOfBeaconsToMatch;
    }
}