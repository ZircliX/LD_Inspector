namespace PuzzleSystem.Core
{
    public abstract class Puzzle<T> : IPuzzle
        where T : IPuzzleContext
    {
        public abstract void Begin(ref T context);

        public abstract bool Refresh(ref T context);

        public abstract void End(ref T context, bool isSuccess);
    }
}