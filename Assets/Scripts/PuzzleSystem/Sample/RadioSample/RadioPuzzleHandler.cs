using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class RadioPuzzleHandler : MonoBehaviour, IPuzzleHandler<RadioContext>
    {
        public Radio radio;
        public Battery battery;
        
        [Space(10)]
        [SerializeField] private AudioClip clip;
        
        private RadioPuzzle puzzle;

        private void Start()
        {
            puzzle = new RadioPuzzle(clip);
            PuzzleManager.Instance.StartPuzzle(puzzle, this);
        }

        public RadioContext GetContext()
        {
            return new RadioContext
            {
                battery = battery,
                radio = radio
            };
        }
    }
}