namespace Puzzles.Day04_GiantSquidBingo;

class BingoCell
{
    public int Number { get; }
    public bool Called { get; private set; }

    public BingoCell(int number)
    {
        Number = number;
    }

    public void NumberCalled(int calledNumber)
    {
        if (Number == calledNumber)
            Called = true;
    }

    public override string ToString()
    {
        return Called ? $"*{Number}*" : Number.ToString();
    }
}