using AsconTest.InputProviders.InputInterface;
using GemTest.InputProviders;
using GemTest.Solver;

public class Program
{
    public static async Task Main()
    {
        InputSelector inputSelector = new InputSelector();
        IInputProvider inputProvider = inputSelector.SelectInputProvider();
        QuadraticSolver solver = new QuadraticSolver();

        IEnumerable<string> inputLines = await inputProvider.GetInputLinesAsync();
        foreach (string input in inputLines)
            solver.SolveQuadraticEquation(input);
    }
}