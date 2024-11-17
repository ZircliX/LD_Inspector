using PuzzleSystem.Core;
using UnityEngine;
using TMPro;

namespace PuzzleSystem.Sample
{
    public class TableauPuzzleHandler : MonoBehaviour, IPuzzleHandler<TableauContext>
    {
        [Header("References")]
        [SerializeField] private Tableau tableau;
        [SerializeField] private TableauPlayer player;
        [SerializeField] private GameObject instructions;
        
        [Header("Code")]
        [SerializeField] private string codeToMatch;
        public TMP_InputField playerInput;
        
        [Header("Audio")]
        [SerializeField] private AudioClip audioClip;
        
        private TableauPuzzle puzzle;
        private bool isPuzzleActive;
        private bool isPuzzleDone;
        
        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStarted += PuzzleState;
            PuzzleManager.Instance.OnPuzzleStopped += PuzzleState;
        }
        
        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStopped -= PuzzleState;
            PuzzleManager.Instance.OnPuzzleStarted -= PuzzleState;
        }

        private void PuzzleState(IPuzzleRunner runner)
        {
            if (runner.Puzzle.GetType() == typeof(TableauPuzzle))
            {
                isPuzzleActive = !isPuzzleActive;
                player.PuzzleState(runner, isPuzzleActive);

                if (!isPuzzleActive)
                {
                    isPuzzleDone = true;
                    instructions.SetActive(false);
                }
            }
        }
        
        private void Update()
        {
            if (isPuzzleDone) return;
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                puzzle = new TableauPuzzle(audioClip);
                PuzzleManager.Instance.StartPuzzle(puzzle, this);
            }
        }
        
        public TableauContext GetContext()
        {
            return new TableauContext
            {
                tableau = tableau,
                codeToMatch = codeToMatch,
                playerCode = playerInput.text
            };
        }
    }
}