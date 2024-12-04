using PuzzleSystem.Core;
using TMPro;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class TableauHandler : MonoBehaviour, IPuzzleHandler<TableauContext>
    {
        [SerializeField] private MonoBehaviour[] tableauScripts;
        
        [SerializeField] private Transform tableau;
        [SerializeField] private TMP_InputField codeInput;
        [SerializeField] private string code;
        private Tableau tableauPuzzle;

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
            tableauPuzzle = new Tableau();
            PuzzleManager.Instance.StartPuzzle(tableauPuzzle, this);
        }
        
        private void OnPuzzleStopped(IPuzzleRunner puzzleRunner)
        {
            if (puzzleRunner.Puzzle is not Tableau) return;

            for (int i = 0; i < tableauScripts.Length; i++)
            {
                tableauScripts[i].enabled = false;
            }
        }
        
        public TableauContext GetContext()
        {
            return new TableauContext
            {
                codeInput = codeInput,
                tableau = tableau,
                code = code,
            };
        }
    }
}
