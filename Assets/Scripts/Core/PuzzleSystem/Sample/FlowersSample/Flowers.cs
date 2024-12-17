using DG.Tweening;
using Menu;
using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class Flowers : Puzzle<FlowersContext>
    {
        public override void Begin(ref FlowersContext context)
        {
        }

        public override bool Refresh(ref FlowersContext context)
        {
            return context.codeInput.text == context.code;
        }

        public override void End(ref FlowersContext context, bool isSuccess)
        {
            context.chest.DORotate(new Vector3(0, -100, 0), 2f);
            context.key.SetActive(true);
            MenuManager.Instance.SwitchMenuState(MenuManager.MenuState.None, GameObject.Find("FlowersCodeInput"));
        }
    }
}
