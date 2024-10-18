using GemTest.Solver;

namespace xUnitQuadraticTests
{
    public class QuadraticSolverTests
    {
        [Theory]
        [InlineData("1 0 -1", "��������� ����� ��� �������������� �����:\n x1 = 1\n x2 = -1")]
        [InlineData("1 0 0", "��������� ����� ���� �������������� ������:\n x = 0")]
        [InlineData("1 -3 2", "��������� ����� ��� �������������� �����:\n x1 = 2\n x2 = 1")]
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
        [InlineData("1 0 a", "�������� ������ ������� ������")]
        [InlineData("1", "�� ����� ������������ ����� �������������.")]
        public void SolveQuadraticEquation_InvalidInput_PrintsErrorMessages(string input, string expectedError)
        {
            // Arrange
            var solver = new QuadraticSolver();
            var writer = new StringWriter();
            Console.SetOut(writer); // ������������� ����� � �������

            // Act
            solver.SolveQuadraticEquation(input);

            // Assert
            var output = writer.GetStringBuilder().ToString().Trim();
            Assert.Contains(expectedError, output);
        }
    }
}