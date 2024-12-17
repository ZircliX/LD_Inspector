using PuzzleSystem.Core;

namespace PuzzleSystem.Sample
{
    public class Books : Puzzle<BooksContext>
    {
        public override void Begin(ref BooksContext context)
        {
        }

        public override bool Refresh(ref BooksContext context)
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

        public override void End(ref BooksContext context, bool isSuccess)
        {
            context.key.SetActive(true);
        }
    }
}