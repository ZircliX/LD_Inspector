using UnityEngine;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        
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
                case MenuManager.MenuState.Pause:
                    menu.SetActive(true);
                    break;
                case MenuManager.MenuState.None:
                    menu.SetActive(false);
                    break;
            }
        }
    }
}