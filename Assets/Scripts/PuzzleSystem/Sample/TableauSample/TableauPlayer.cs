using Menu;
using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class TableauPlayer : MonoBehaviour
    {
        [SerializeField] private MenuManager menu;

        public void PuzzleState(IPuzzleRunner puzzleRunner, bool puzzleState)
        {
            if (puzzleRunner.Puzzle.GetType() != typeof(TableauPuzzle)) return;

            menu.SwitchMenuState(puzzleState ? MenuManager.MenuState.TableauInput : MenuManager.MenuState.None);
        }
    }
}