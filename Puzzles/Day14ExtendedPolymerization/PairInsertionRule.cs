namespace Puzzles.Day14ExtendedPolymerization;

public class PairInsertionRule
{
    public PairInsertionRule(string input)
    {
        Left = input[0];
        Right = input[1];
        Insert = input[6];
    }
        
    public static PairInsertionRule Create(string input) => new(input);

    public char Insert { get;  }

    public char Right { get;  }

    public char Left { get;  }

    public override string ToString() => $"{Left}{Right} -> {Insert}";
}
