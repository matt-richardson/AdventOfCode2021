namespace Puzzles.Day06_Lanternfish;

public class LanternFish
{
    private int internalTimer;
    private readonly Action haveBabyFish;

    public LanternFish(int internalTimer, Action haveBabyFish)
    {
        this.internalTimer = internalTimer;
        this.haveBabyFish = haveBabyFish;
    }

    public void DayPassed()
    {
        internalTimer--;
        if (internalTimer == -1)
        {
            internalTimer = 6;
            haveBabyFish();
        }
    }

    public override string ToString()
    {
        return internalTimer.ToString();
    }
}