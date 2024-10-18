using AsconTest.InputProviders.InputInterface;

namespace GemTest.InputProviders.InputType
{
    public class FileInput : IInputProvider
    {
        private readonly string filePath;

        public FileInput(string filePath)
        {
            this.filePath = filePath;
        }

        public async Task<IEnumerable<string>> GetInputLinesAsync()
        {
            if (File.Exists(filePath))
            {
                return await File.ReadAllLinesAsync(filePath);
            }
            throw new FileNotFoundException($"Файл, расположенный по пути - {filePath}, не найден.");
        }
    }
}