using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class Chests : Puzzle<ChestsContext>
    {
        public override void Begin(ref ChestsContext context)
        {
            
        }

        public override bool Refresh(ref ChestsContext context)
        {
            for (int i = 0; i < context.holders.Length; i++)
            {
                if (!context.holders[i].IsCorrectItem())
                {
                    return false;
                }
            }

            return true;
        }

        public override void End(ref ChestsContext context, bool isSuccess)
        {
            context.door.SetActive(false);
        }
    }
}