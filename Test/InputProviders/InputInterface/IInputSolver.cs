namespace AsconTest.InputProviders.InputInterface
{
    /// <summary>
    /// Интерфейс для получения данных из источника
    /// </summary>
    public interface IInputProvider
    {
        Task<IEnumerable<string>> GetInputLinesAsync();
    }
}