using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace GemTest.Solver
{
    /// <summary>
    /// Класс с методами для решения квадратных уравнений
    /// </summary>
    public class QuadraticSolver
    {
        /// <summary>
        /// Метод для решения квадратных уравнений, когда входными данными являются коэффициенты.
        /// <para>
        /// Разделителем десятичной дроби может быть как запятая, так и точка.
        /// </para>
        /// </summary>
        /// <param name="input"></param>
        public void SolveQuadraticEquation(string input)
        {
            try
            {
                input = input.Replace(',', '.');

                double[] coefficients = input.Split(' ')
                                             .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                                             .ToArray();

                if (coefficients.Length != 3)
                {
                    Console.WriteLine($"Вы ввели неправильное число коэффициентов.");
                    return;
                }

                var a = coefficients[0];
                var b = coefficients[1];
                var c = coefficients[2];

                Console.WriteLine($"\nУравнение выглядит следующим образом:\n {a}x^2 + {b}x + {c} = 0");
                Solve(a, b, c);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат входных данных");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        private void Solve(double a, double b, double c)
        {
            double discr = b * b - 4 * a * c;
            if (a == 0)
            {
                if (b != 0)
                {
                    var x = -c / b;
                    Console.WriteLine($"Это линейное уравнение. Единственный корень:\n x = {Math.Round(x, 3)}");
                }
                else
                    Console.WriteLine("Это не уравнение.");
            }
            else if (discr > 0)
            {
                var x1 = (-b + Math.Sqrt(discr)) / (2 * a);
                var x2 = (-b - Math.Sqrt(discr)) / (2 * a);
                if (x1 == -0)
                    x1 = 0;
                if (x2 == -0)
                    x2 = 0;
                Console.WriteLine($"Уравнение имеет два действительных корня:\n x1 = {Math.Round(x1, 3)}\n x2 = {Math.Round(x2, 3)}");
            }
            else if (discr == 0)
            {
                var x = -b / (2 * a);
                if (x == -0)
                    x = 0;
                Console.WriteLine($"Уравнение имеет один действительный корень:\n x = {Math.Round(x, 3)}");
            }
            else
            {
                var realPart = -b / (2 * a);
                var iPart = Math.Sqrt(-discr) / (2 * a);
                Console.WriteLine($"Уравнение имеет два комплексных корня:\n x1 = {Math.Round(realPart, 3)} + {Math.Round(iPart, 3)}i\n x2 = {Math.Round(realPart, 3)} - {Math.Round(iPart, 3)}i");
            }
        }
    }
}