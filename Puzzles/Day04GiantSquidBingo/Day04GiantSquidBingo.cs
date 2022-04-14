// See https://adventofcode.com/2021/day/3

namespace Puzzles.Day04GiantSquidBingo;

public class Day04GiantSquidBingo : IPuzzle
{
    public (object answer1, object answer2) Calculate()
    {
        var diagnosticReport = Helpers.ReadInputData(nameof(Day04GiantSquidBingo));

        return (
            CalculatePart1(diagnosticReport),
            CalculatePart2(diagnosticReport)
        );
    }

    public static int CalculatePart1(string[] bingoData)
    {
        var (bingoNumbers, bingoBoards) = ParseBingoData(bingoData);

        foreach (var bingoNumber in bingoNumbers)
        {
            foreach (var board in bingoBoards)
            {
                board.NumberCalled(bingoNumber);
                if (board.IsBingo())
                    return board.GetSumOfAllUnCalledNumbers() * bingoNumber;
            }
        }
        return 0;
    }

    private static (int[] bingoNumbers, BingoBoard[] bingoBoards) ParseBingoData(string[] bingoData)
    {
        var bingoNumbers = bingoData[0].Split(",").Select(int.Parse).ToArray();

        var bingoBoards = new List<BingoBoard>();
        for (var i = 2; i < bingoData.Length; i += 6)
        {
            var bingoBoard = new BingoBoard(bingoData.Skip(i).Take(5));
            bingoBoards.Add(bingoBoard);
        }

        return (bingoNumbers, bingoBoards.ToArray());
    }

    public static int CalculatePart2(string[] bingoData)
    {
        var (bingoNumbers, bingoBoards) = ParseBingoData(bingoData);

        var remainingBoards = bingoBoards.ToList();

        foreach (var bingoNumber in bingoNumbers)
        {
            foreach (var board in bingoBoards)
            {
                board.NumberCalled(bingoNumber);
                if (board.IsBingo())
                {
                    if (remainingBoards.Contains(board) && remainingBoards.Count == 1)
                        return board.GetSumOfAllUnCalledNumbers() * bingoNumber;

                    if (remainingBoards.Contains(board))
                        remainingBoards.Remove(board);
                }
            }
        }
        return 0;
    }
}
