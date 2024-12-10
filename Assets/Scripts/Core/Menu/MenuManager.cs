using System;
using LTX.ChanneledProperties;
using CyberEnigma.Core;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menu
{
    public class MenuManager : MonoSingleton<MenuManager>
    {
        public event Action<MenuState, GameObject> OnMenuChange;

        public MenuState menuState { get; private set; } = MenuState.None;
        public enum MenuState
        {
            None = -1,
            Pause = 0,
            Inventory = 1,
            RequireInput = 2
        }
        
        private void OnEnable()
        {
            GameController.CursorVisibility.AddPriority(this, PriorityTags.None, true);
            GameController.CursorLockMode.AddPriority(this, PriorityTags.None, CursorLockMode.None);
            
            GameController.TimeScale.AddPriority(this, PriorityTags.None, 0f);
        }

        private void OnDisable()
        {
            GameController.CursorVisibility.RemovePriority(this);
            GameController.CursorLockMode.RemovePriority(this);

            GameController.TimeScale.RemovePriority(this);
        }

        public void OnInventoryInput(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            SwitchMenuState(menuState == MenuState.None ? MenuState.Inventory : MenuState.None, new GameObject());
        }

        public void OnPausedInput(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            SwitchMenuState(menuState is MenuState.Pause or MenuState.Inventory or MenuState.RequireInput
                ? MenuState.None
                : MenuState.Pause, new GameObject());
        }

        public void SwitchMenuState(MenuState newMenuState, GameObject panel)
        {
            menuState = newMenuState;
            OnMenuChange?.Invoke(newMenuState, panel);
            
            GameController.CursorVisibility.ChangeChannelPriority(this, CheckPriorities());
            GameController.CursorLockMode.ChangeChannelPriority(this, CheckPriorities());
            GameController.TimeScale.ChangeChannelPriority(this, CheckPriorities());
        }

        private PriorityTags CheckPriorities()
        {
            return menuState == MenuState.None ? PriorityTags.None : PriorityTags.High;
        }
    }
}