using System.Diagnostics;

namespace Puzzles.Day11DumboOctopus;

[DebuggerDisplay("({RowNumber},{ColNumber}): EnergyLevel {EnergyLevel}")]
public class Octopus
{
    public int EnergyLevel { get; private set; }
    private bool hasFlashed;

    public Octopus(int rowNumber, int colNumber, int energyLevel) 
    {
        RowNumber = rowNumber;
        ColNumber = colNumber;
        EnergyLevel = energyLevel;
    }

    public int RowNumber { get; }
    public int ColNumber { get; }

    public event EventHandler OnFlash;

    public void WithNeighbours(Octopus? upLeft,
        Octopus? upMiddle,
        Octopus? upRight,
        Octopus? left,
        Octopus? right,
        Octopus? downLeft,
        Octopus? downMiddle,
        Octopus? downRight)
    {
        if (upLeft != null) upLeft.OnFlash += NeighbourFlashed;
        if (upMiddle != null) upMiddle.OnFlash += NeighbourFlashed;
        if (upRight != null) upRight.OnFlash += NeighbourFlashed;
        if (left != null) left.OnFlash += NeighbourFlashed;
        if (right != null) right.OnFlash += NeighbourFlashed;
        if (downLeft != null) downLeft.OnFlash += NeighbourFlashed;
        if (downMiddle != null) downMiddle.OnFlash += NeighbourFlashed;
        if (downRight != null) downRight.OnFlash += NeighbourFlashed;
    }

    private void NeighbourFlashed(object? sender, EventArgs e)
    {
        EnergyLevel++;
        FlashIfRequired();
    }

    public void Step()
    {
        EnergyLevel++;
    }

    public void FlashIfRequired()
    {
        if (EnergyLevel > 9 && !hasFlashed)
        {
            hasFlashed = true;
            OnFlash?.Invoke(this, EventArgs.Empty);
        }
    }

    public void ResetIfRequired()
    {
        if (hasFlashed)
            EnergyLevel = 0;
        hasFlashed = false;
    }
    
#region Equality Comparers
    protected bool Equals(Octopus other)
    {
        return RowNumber == other.RowNumber && ColNumber == other.ColNumber;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Octopus) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RowNumber, ColNumber);
    }
#endregion
}
