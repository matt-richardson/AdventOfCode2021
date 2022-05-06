namespace Puzzles.Day10SyntaxScoring;

public class AutoCompleteContest
{
    private readonly long[] scores;

    public AutoCompleteContest(IEnumerable<long> scores)
    {
        //validation for odd number
        this.scores = scores.OrderBy(x => x).ToArray();
    }

    public long MiddleScore => scores[scores.Length / 2];
}
