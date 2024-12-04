using UnityEngine;

namespace Menu
{
    public class InventoryMenu : MonoBehaviour
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

        private void SwitchState(MenuManager.MenuState newState)
        {
            switch (newState)
            {
                case MenuManager.MenuState.Inventory:
                    menu.SetActive(true);
                    break;
                case MenuManager.MenuState.None:
                    menu.SetActive(false);
                    break;
            }
        }
    }
}