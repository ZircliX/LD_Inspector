using DG.Tweening;
using Menu;
using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class Tableau : Puzzle<TableauContext>
    {
        public override void Begin(ref TableauContext context)
        {
        }

        public override bool Refresh(ref TableauContext context)
        {
            return context.codeInput.text == context.code;
        }

        public override void End(ref TableauContext context, bool isSuccess)
        {
            context.tableau.DOMoveZ(1.5f, 2f);
            MenuManager.Instance.SwitchMenuState(MenuManager.MenuState.None, GameObject.Find("TableauCodeInput"));
        }
    }
}