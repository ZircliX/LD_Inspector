using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class TableauHandler : MonoBehaviour, IPuzzleHandler<TableauContext>
    {
        private Tableau tableauPuzzle;
        
        public void StartPuzzle()
        {
            tableauPuzzle = new Tableau();
            PuzzleManager.Instance.StartPuzzle(tableauPuzzle, this);
        }
        
        public TableauContext GetContext()
        {
            return new TableauContext
            {

            };
        }
    }
}
