using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class ChestsHandler : MonoBehaviour, IPuzzleHandler<ChestsContext>
    {
        [SerializeField] private MonoBehaviour[] chestsScripts;
        [SerializeField] private ChestHolder[] holders;
        [SerializeField] private GameObject door;
        
        private Chests flowersPuzzle;
        
        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStopped += OnPuzzleStopped;
        }

        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStopped -= OnPuzzleStopped;
        }

        private void Start()
        {
            flowersPuzzle = new Chests();
            PuzzleManager.Instance.StartPuzzle(flowersPuzzle, this);
        }
        
        private void OnPuzzleStopped(IPuzzleRunner puzzleRunner)
        {
            if (puzzleRunner.Puzzle is not Chests) return;

            for (int i = 0; i < chestsScripts.Length; i++)
            {
                chestsScripts[i].enabled = false;
            }
        }
        
        public ChestsContext GetContext()
        {
            return new ChestsContext
            {
                holders = holders,
                door = door,
            };
        }
    }
}