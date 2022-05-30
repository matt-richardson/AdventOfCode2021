namespace Puzzles.Day12PassagePathing.VisitTrackers;

public interface IVisitTracker
{
    bool CanVisit(Cave cave);
    void Visit(Cave cave);
    IVisitTracker Clone();
}
