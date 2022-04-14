using System.Diagnostics;

public class NaiveLanternFishSchool
{
    int day = 0;
    int newFish = 0;
    readonly List<LanternFish> lanternFishes = new();
    void NewFishyBorn() => newFish++;

    public NaiveLanternFishSchool(IEnumerable<int> initialInternalFishTimers)
    {
        lanternFishes.AddRange(initialInternalFishTimers.Select(x => new LanternFish(x, NewFishyBorn)));
    }

    public void DayPassed()
    {
        var stopwatch = Stopwatch.StartNew();
        newFish = 0;
        foreach (var fish in lanternFishes)
            fish.DayPassed();
        for (var i = 0; i < newFish; i++)
            lanternFishes.Add(new LanternFish(8, NewFishyBorn));
        Console.WriteLine($"At the end of day {day++}, there are {Count} lantern fish (spawning took {stopwatch.Elapsed.TotalSeconds} seconds)" );
    }

    public int Count => lanternFishes.Count;
}
