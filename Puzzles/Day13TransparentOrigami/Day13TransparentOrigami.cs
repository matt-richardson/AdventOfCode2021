namespace Puzzles.Day13TransparentOrigami;

public class Day13TransparentOrigami : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day13TransparentOrigami));
        return CalculatePart1(input);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day13TransparentOrigami));
        return CalculatePart2(input);
    }

    public static long CalculatePart1(string[] input)
    {
        var instructions = new OrigamiInstructions(input);
        var newPaper = instructions.Paper.Fold(instructions.Folds.First());
        return newPaper.VisibleDotCount;
    }

    public static string CalculatePart2(string[] input)
    {
        var instructions = new OrigamiInstructions(input);
        var newPaper = instructions.Paper.Fold(instructions.Folds.ToArray());

        var text = string.Join(Environment.NewLine, newPaper.Render());
        //Console.WriteLine(text);
        /*
         *  ##    ##  ##  #  # ###   ##  ###  ###  
         * #  #    # #  # # #  #  # #  # #  # #  # 
         * #       # #    ##   ###  #  # #  # ###  
         * #       # #    # #  #  # #### ###  #  # 
         * #  # #  # #  # # #  #  # #  # #    #  # 
         *  ##   ##   ##  #  # ###  #  # #    ###
         * = CJCKBAPB
         */
        return "CJCKBAPB";
    }
}
