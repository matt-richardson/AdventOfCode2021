using System.Diagnostics;

namespace Puzzles.Day06LanternFish;

public class LanternFishSchool
{
    int day = 0;
    long[] fishCounts = new long[9];

    public LanternFishSchool(IEnumerable<int> initialInternalFishTimers)
    {
        foreach (var fishTimer in initialInternalFishTimers)
            fishCounts[fishTimer]++;
    }

    public void DayPassed()
    {
        var stopwatch = Stopwatch.StartNew();

        var fishAboutToSpawn = fishCounts[0];
        fishCounts[0] = fishCounts[1];
        fishCounts[1] = fishCounts[2];
        fishCounts[2] = fishCounts[3];
        fishCounts[3] = fishCounts[4];
        fishCounts[4] = fishCounts[5];
        fishCounts[5] = fishCounts[6];
        fishCounts[6] = fishCounts[7] + fishAboutToSpawn;
        fishCounts[7] = fishCounts[8];
        fishCounts[8] = fishAboutToSpawn;

        // Console.WriteLine($"At the end of day {day++}, there are {Count} lantern fish (spawning took {stopwatch.Elapsed.TotalSeconds} seconds)" );
    }

    public override string ToString()
    {
        return string.Join(",", fishCounts);
    }

    public long Count =>
        fishCounts[0] +
        fishCounts[1] +
        fishCounts[2] +
        fishCounts[3] +
        fishCounts[4] +
        fishCounts[5] +
        fishCounts[6] +
        fishCounts[7] +
        fishCounts[8];
}
