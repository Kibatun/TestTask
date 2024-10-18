using GemTest.Solver;

namespace xUnitQuadraticTests
{
    public class QuadraticSolverTests
    {
        [Theory]
        [InlineData("1 0 -1", "Уравнение имеет два действительных корня:\n x1 = 1\n x2 = -1")]
        [InlineData("1 0 0", "Уравнение имеет один действительный корень:\n x = 0")]
        [InlineData("1 -3 2", "Уравнение имеет два действительных корня:\n x1 = 2\n x2 = 1")]
        public void SolveQuadraticEquation_ValidInput_PrintsCorrectOutput(string input, string expectedOutput)
        {
            // Arrange
            var solver = new QuadraticSolver();
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            solver.SolveQuadraticEquation(input);

            // Assert
            var output = writer.GetStringBuilder().ToString().Trim();
            Assert.Contains(expectedOutput, output);
        }

        [Theory]
        [InlineData("1 0 a", "Неверный формат входных данных")]
        [InlineData("1", "Вы ввели неправильное число коэффициентов.")]
        public void SolveQuadraticEquation_InvalidInput_PrintsErrorMessages(string input, string expectedError)
        {
            // Arrange
            var solver = new QuadraticSolver();
            var writer = new StringWriter();
            Console.SetOut(writer); // Перехватываем вывод в консоль

            // Act
            solver.SolveQuadraticEquation(input);

            // Assert
            var output = writer.GetStringBuilder().ToString().Trim();
            Assert.Contains(expectedError, output);
        }
    }
}