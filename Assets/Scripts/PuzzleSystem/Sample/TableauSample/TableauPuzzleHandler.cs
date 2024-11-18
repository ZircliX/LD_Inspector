using Menu;
using PuzzleSystem.Core;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

namespace PuzzleSystem.Sample
{
    public class TableauPuzzleHandler : MonoBehaviour, IPuzzleHandler<TableauContext>
    {
        [Header("References")]
        [SerializeField] private Tableau tableau;
        [SerializeField] private GameObject instructions;
        [SerializeField] private MenuManager menu;
        [SerializeField] private TableauPlayer player;
        
        [Header("Code")]
        [SerializeField] private string codeToMatch;
        public TMP_InputField playerInput;
        
        private TableauPuzzle puzzle;
        private bool isPuzzleActive;
        
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

        private void Start()
        {
            tableau.instructions = instructions;
        }

        private void PuzzleState(IPuzzleRunner runner)
        {
            if (runner.Puzzle.GetType() == typeof(TableauPuzzle))
            {
                isPuzzleActive = !isPuzzleActive;
                tableau.isActive = isPuzzleActive;

                if (!isPuzzleActive)
                {
                    menu.SwitchMenuState(MenuManager.MenuState.None);
                    instructions.GetComponent<TextMeshProUGUI>().text = "";
                }
            }
        }
        
        public void OpenCodeInput(InputAction.CallbackContext context)
        {
            if (!isPuzzleActive || !player.isInArea || !context.performed) return;

            if (menu.menuState == MenuManager.MenuState.TableauInput)
            {
                menu.SwitchMenuState(MenuManager.MenuState.None);
                playerInput.text = "";
            }
            else if (menu.menuState == MenuManager.MenuState.None)
            {
                menu.SwitchMenuState(MenuManager.MenuState.TableauInput);
            }
        }

        public void StartPuzzle()
        {
            puzzle = new TableauPuzzle();
            PuzzleManager.Instance.StartPuzzle(puzzle, this);
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