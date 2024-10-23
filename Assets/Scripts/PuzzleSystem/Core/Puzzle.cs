using PuzzleSystem.Core.Data;

namespace PuzzleSystem.Core
{
    public class Puzzle
    {
        public bool isDirty { get; private set; }

        public readonly PuzzleData puzzleData;
        public Puzzle(PuzzleData puzzleData)
        {
            this.puzzleData = puzzleData;
            isDirty = true;
        }

        /// <summary>
        /// Signal something has changed
        /// </summary>
        public void SetDirty()
        {
            isDirty = true;
        }

        /// <summary>
        /// Update from the manager
        /// </summary>
        public bool Refresh()
        {
            //If nothing has changed, return
            if (!isDirty) return false;

            //Only one refresh
            isDirty = false;

            if (!puzzleData.Refresh()) return false;
            
            //Done
            return true;
        }
    }
}