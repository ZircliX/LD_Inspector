using Menu;
using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class TableauPlayer : MonoBehaviour
    {
        [SerializeField] private MenuManager menu;

        private bool isPuzzleActive;

        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStopped += PuzzleState;
            PuzzleManager.Instance.OnPuzzleStarted += PuzzleState;
        }
        
        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStopped -= PuzzleState;
            PuzzleManager.Instance.OnPuzzleStarted -= PuzzleState;
        }

        private void PuzzleState(IPuzzleRunner puzzleRunner)
        {
            if (puzzleRunner.Puzzle.GetType() == typeof(TableauPuzzle))
            {
                isPuzzleActive = !isPuzzleActive;

                if (isPuzzleActive)
                {
                    menu.SwitchMenuState(MenuManager.MenuState.TableauInput);
                }
                else
                {
                    menu.SwitchMenuState(MenuManager.MenuState.None);
                }
            }
        }
    }
}