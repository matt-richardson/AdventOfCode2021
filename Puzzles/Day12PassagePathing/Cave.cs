using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace Puzzles.Day12PassagePathing;

public record Cave(string Name)
{
    public bool IsStart => Name == "start";
    public bool IsEnd => Name == "end";
    public bool IsBigCave => !IsStart && !IsEnd && char.IsUpper(Name.First());
    public bool IsLittleCave => !IsBigCave;

    public void Connect(IEnumerable<CaveConnection> connections, IEnumerable<Cave> caves)
    {
        var enumerable = connections.Select(x => x.StartingCave == Name ? x.EndingCave : x.StartingCave);
        
        ConnectedCaves = new ReadOnlyCollection<Cave>(caves.Where(x => enumerable.Contains(x.Name)).ToList());
    }

    public ReadOnlyCollection<Cave> ConnectedCaves { get; private set; } = new(new ImmutableArray<Cave>());
}
