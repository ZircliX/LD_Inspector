using UnityEngine;

namespace Menu
{
    public class CodeInputMenu : MonoBehaviour
    {
        private void OnEnable()
        {
            MenuManager.Instance.OnMenuChange += SwitchState;
        }

        private void OnDisable()
        {
            MenuManager.Instance.OnMenuChange -= SwitchState;
        }

        private void SwitchState(MenuManager.MenuState newState, GameObject panel)
        {
            switch (newState)
            {
                case MenuManager.MenuState.RequireInput:
                    panel.SetActive(true);
                    break;
                case MenuManager.MenuState.None:
                    if (panel.name == "Canvas") return;
                    panel.SetActive(false);
                    break;
            }
        }
    }
}