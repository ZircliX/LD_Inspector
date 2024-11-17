using PuzzleSystem.Core;
using UnityEngine;
using TMPro;

namespace PuzzleSystem.Sample
{
    public class TableauPuzzleHandler : MonoBehaviour, IPuzzleHandler<TableauContext>
    {
        [SerializeField] private Tableau tableau;
        [SerializeField] private string codeToMatch;
        public TMP_InputField playerInput;
        [SerializeField] private AudioClip audioClip;
        
        private TableauPuzzle puzzle;
        
        private void Update()
        {
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