using UnityEngine;

namespace Menu
{
    public class CodeInputMenu : MonoBehaviour
    {
        private GameObject currentPanel;
        
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
                    currentPanel = panel;
                    break;
                case MenuManager.MenuState.None:
                    if (panel.name == "Canvas" || currentPanel == null) return;
                    
                    currentPanel.SetActive(false);
                    currentPanel = null;
                    
                    Debug.Log("Input menu active false");
                    break;
            }
        }
    }
}