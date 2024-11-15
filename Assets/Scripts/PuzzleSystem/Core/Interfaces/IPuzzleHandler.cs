namespace PuzzleSystem.Core
{
    public interface IPuzzleHandler<T> where T : IPuzzleContext
    {
        T GetContext();
    }
}