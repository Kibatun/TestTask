using AsconTest.InputProviders.InputInterface;
using GemTest.InputProviders.InputType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemTest.InputProviders
{
    /// <summary>
    /// Класс выбора способа введения данных
    /// </summary>
    public class InputSelector
    {
        public IInputProvider SelectInputProvider()
        {
            Console.WriteLine("Введите путь к txt-файлу без кавычек или нажмите Enter для перехода к вводу с клавиатуры:");
            string filePath = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(filePath))
                return new FileInput(filePath);
            else
                return new ConsoleInput();
        }
    }
}