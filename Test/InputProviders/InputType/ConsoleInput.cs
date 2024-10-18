using AsconTest.InputProviders.InputInterface;

namespace GemTest.InputProviders.InputType
{
    internal class ConsoleInput : IInputProvider
    {
        public Task<IEnumerable<string>> GetInputLinesAsync()
        {
            var inputList = new List<string>();
            Console.WriteLine("Введите коэффициенты уравнений в формате 'a b c', где каждое новое уравнение со следующей строки.\nДля завершения ввода данных нажмите Enter Дважды.");
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                inputList.Add(line);

            return Task.FromResult<IEnumerable<string>>(inputList);
        }
    }
}