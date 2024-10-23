using UnityEngine;

namespace PuzzleSystem.Core.Data
{
    public abstract class PuzzleData : ScriptableObject
    {
        [field: SerializeField]
        public string PuzzleName { get; private set; }
        
        [field: SerializeField]
        public ConditionData[] Conditions { get; private set; }

        public abstract void Begin();
        public abstract bool Refresh();
        public abstract void End(bool isSuccess);
        
        public bool AreAllConditionCompleted()
        {
            for (var i = 0; i < Conditions.Length; i++)
            {
                ConditionData condition = Conditions[i];
                if (condition != null)
                {
                    if (!condition.IsComplete()) return false;
                }
            }

            return true;
        }

        public Puzzle ToPuzzle()
        {
            return new Puzzle(this);
        }
    }
}