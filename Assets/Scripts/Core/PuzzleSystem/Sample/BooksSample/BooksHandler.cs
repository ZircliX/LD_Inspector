using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class BooksHandler : MonoBehaviour, IPuzzleHandler<BooksContext>
    {
        [SerializeField] private MonoBehaviour[] booksScripts;
        [SerializeField] private BookHolder[] holders;

        private Books booksPuzzle;
        
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
            booksPuzzle = new Books();
            PuzzleManager.Instance.StartPuzzle(booksPuzzle, this);
        }
        
        private void OnPuzzleStopped(IPuzzleRunner puzzleRunner)
        {
            if (puzzleRunner.Puzzle is not Flowers) return;

            for (int i = 0; i < booksScripts.Length; i++)
            {
                booksScripts[i].enabled = false;
            }
        }
        
        public BooksContext GetContext()
        {
            return new BooksContext
            {
                holders = holders,
            };
        }
    }
}