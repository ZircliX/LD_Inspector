using System;
using LTX.ChanneledProperties;
using CyberEnigma.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] PanelList;

        public MenuState menuState;

        public enum MenuState
        {
            None = -1,
            Pause = 0,
            Inventory = 1,
            TableauInput = 2
        }

        public void OnInventoryInput(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            if (menuState == MenuState.None)
            {
                SwitchMenuState(MenuState.Inventory);
                return;
            }
            
            SwitchMenuState(MenuState.None);
        }

        public void OnPausedInput(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            if (menuState is MenuState.Pause or MenuState.Inventory or MenuState.TableauInput)
            {
                SwitchMenuState(MenuState.None);
                return;
            }
            
            SwitchMenuState(MenuState.Pause);
        }

        public void SwitchMenuState(MenuState newMenuState)
        {
            foreach (GameObject panel in PanelList)
            {
                panel.SetActive(false);
            }

            menuState = newMenuState;
            switch (menuState)
            {
                case MenuState.Pause:
                    GameController.CursorVisibility.ChangeChannelPriority(this, PriorityTags.High);
                    GameController.CursorLockMode.ChangeChannelPriority(this, PriorityTags.High);
                    Time.timeScale = 0f;
                    break;
                case MenuState.Inventory:
                    Time.timeScale = 0f;
                    GameController.CursorVisibility.ChangeChannelPriority(this, PriorityTags.High);
                    GameController.CursorLockMode.ChangeChannelPriority(this, PriorityTags.High);
                    break;
                case MenuState.None:
                    GameController.CursorVisibility.ChangeChannelPriority(this, PriorityTags.None);
                    GameController.CursorLockMode.ChangeChannelPriority(this, PriorityTags.None);
                    Time.timeScale = 1f;
                    return;
                case MenuState.TableauInput:
                    Time.timeScale = 0f;
                    GameController.CursorVisibility.ChangeChannelPriority(this, PriorityTags.High);
                    GameController.CursorLockMode.ChangeChannelPriority(this, PriorityTags.High);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            PanelList[(int)menuState].SetActive(true);
        }

        private void OnEnable()
        {
            GameController.CursorVisibility.AddPriority(this, PriorityTags.None, true);
            GameController.CursorLockMode.AddPriority(this, PriorityTags.None, CursorLockMode.None);
        }

        private void OnDisable()
        {
            //Enlever channel
            GameController.CursorVisibility.RemovePriority(this);
            GameController.CursorLockMode.RemovePriority(this);
        }
    }
}