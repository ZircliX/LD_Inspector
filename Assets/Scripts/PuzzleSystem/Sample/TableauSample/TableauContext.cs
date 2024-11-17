using PuzzleSystem.Core;

namespace PuzzleSystem.Sample
{
    public struct TableauContext : IPuzzleContext
    {
        public Tableau tableau;
        public string codeToMatch;
        public string playerCode;
    }
}