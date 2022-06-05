namespace Puzzles.Day13TransparentOrigami;

public class Day13TransparentOrigami : IPuzzle
{
    public (object answer1, object answer2) Calculate()
    {
        var input = Helpers.ReadInputData(nameof(Day13TransparentOrigami));

        return (
            CalculatePart1(input),
            CalculatePart2(input)
        );
    }

    public static long CalculatePart1(string[] input)
    {
        var instructions = new OrigamiInstructions(input);
        var newPaper = instructions.Paper.Fold(instructions.Folds.First());
        return newPaper.VisibleDotCount();
    }

    public static long CalculatePart2(string[] input)
    {
        var instructions = new OrigamiInstructions(input);
        var newPaper = instructions.Paper.Fold(instructions.Folds);
        Console.WriteLine(newPaper.Render());
        /*
         *  ##    ##  ##  #  # ###   ##  ###  ###  
         * #  #    # #  # # #  #  # #  # #  # #  # 
         * #       # #    ##   ###  #  # #  # ###  
         * #       # #    # #  #  # #### ###  #  # 
         * #  # #  # #  # # #  #  # #  # #    #  # 
         *  ##   ##   ##  #  # ###  #  # #    ###
         * = CJCKBAPB
         */
        return newPaper.VisibleDotCount();
    }
}
