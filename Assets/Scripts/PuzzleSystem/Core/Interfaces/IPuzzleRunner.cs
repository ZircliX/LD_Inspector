namespace PuzzleSystem.Core
{
    public interface IPuzzleRunner
    {
        IPuzzle Puzzle { get; }
        
        void Begin();
        bool Refresh();
        void End(bool isSuccess);
    }
}