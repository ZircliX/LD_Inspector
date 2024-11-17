using System;
using LTX.ChanneledProperties;
using TheLastWitness.Core;
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
            Options = 1,
            Inventory = 2,
            TableauInput = 3
        }

        public void OnInventoryInput(InputAction.CallbackContext context)
        {
            if (menuState == MenuState.None)
            {
                SwitchMenuState(MenuState.Inventory);
            }
            else if (menuState == MenuState.Inventory)
            {
                SwitchMenuState(MenuState.None);
            }
        }

        public void OnPausedInput(InputAction.CallbackContext context)
        {
            if (menuState == MenuState.Options)
            {
                SwitchMenuState(MenuState.Pause);
            }
            else if (menuState == MenuState.Pause)
            {
                SwitchMenuState(MenuState.None);
            }
            else
            {
                SwitchMenuState(MenuState.Pause);
            }
        }

        public void OnStateSwitch(int index)
        {
            SwitchMenuState((MenuState)index);
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
                case MenuState.Options:
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