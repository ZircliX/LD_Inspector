using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class PuzzleSampleManager : MonoBehaviour
    {
        [SerializeField] private SamplePuzzleData puzzleData;

        private Puzzle puzzle;
        
        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStarted += OnPuzzleStarted;
            PuzzleManager.Instance.OnPuzzleStopped += OnPuzzleStopped;
        }
        
        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStarted -= OnPuzzleStarted;
            PuzzleManager.Instance.OnPuzzleStopped -= OnPuzzleStopped;
        }

        private void Start()
        {
            puzzle = puzzleData.ToPuzzle();
            PuzzleManager.Instance.StartPuzzle(puzzle);
        }

        private void LateUpdate()
        {
            if (Input.GetKey(puzzleData.keyCode))
                puzzle.SetDirty();
        }

        private void OnPuzzleStarted(Puzzle puzzle)
        {
            Debug.Log($"Puzzle {puzzle.puzzleData.PuzzleName} has started");
        }
        
        private void OnPuzzleStopped(Puzzle puzzle)
        {
            Debug.Log($"Puzzle {puzzle.puzzleData.PuzzleName} has stopped");
        }
    }
}