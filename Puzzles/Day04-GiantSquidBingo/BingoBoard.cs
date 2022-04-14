using System.Text;

namespace Puzzles.Day04_GiantSquidBingo;

internal class BingoBoard
{
    public BingoBoard(IEnumerable<string> data)
    {
        this.data = data.Select(ParseRow).ToArray();
    }

    private static BingoCell[] ParseRow(string row)
    {
        return row
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(y => y.Trim())
            .Select(z => new BingoCell(int.Parse(z)))
            .ToArray();
    }

    readonly BingoCell[][] data;

    public void NumberCalled(int calledNumber)
    {
        foreach(var row in data)
        foreach (var cell in row)
            cell.NumberCalled(calledNumber);
    }

    public bool IsBingo()
    {
        for (var i = 0; i < 5; i++)
        {
            if (data[i][0].Called && data[i][1].Called && data[i][2].Called && data[i][3].Called && data[i][4].Called)
                return true;
        }

        for (var i = 0; i < 5; i++)
        {
            if (data[0][i].Called && data[1][i].Called && data[2][i].Called && data[3][i].Called && data[4][i].Called)
                return true;
        }

        return false;
    }

    public int GetSumOfAllUnCalledNumbers()
    {
        var result = 0;
        foreach(var row in data)
            result = row.Where(cell => !cell.Called).Aggregate(result, (current, cell) => current + cell.Number);
        return result;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var row in data)
            sb.AppendLine(string.Join(" ", row.Select(x => x.ToString())));
        return sb.ToString();
    }
}