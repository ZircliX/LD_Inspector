using LTX.Singletons;
using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class RadioSetup : MonoSingleton<RadioSetup>
    {
        [SerializeField] public Radio radio;
        [SerializeField] public Battery battery;
        [SerializeField] public PlayerExample player;
        [SerializeField] private RadioPuzzleData radioPuzzleData;
        
        private Puzzle puzzle;

        private void Start()
        {
            puzzle = new Puzzle(radioPuzzleData);
            PuzzleManager.Instance.StartPuzzle(puzzle);
        }

        public void SetDirty()
        {
            puzzle.SetDirty();
        }
    }
}