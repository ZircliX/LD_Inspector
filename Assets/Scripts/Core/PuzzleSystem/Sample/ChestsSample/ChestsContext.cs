using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public struct ChestsContext : IPuzzleContext
    {
        public ChestHolder[] holders;
        public GameObject door;
    }
}