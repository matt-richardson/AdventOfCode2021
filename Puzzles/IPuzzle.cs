namespace Puzzles;

public interface IPuzzle
{
    (object answer1, object answer2) Calculate();
}
