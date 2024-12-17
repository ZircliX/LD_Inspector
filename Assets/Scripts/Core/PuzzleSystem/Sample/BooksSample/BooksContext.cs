using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public struct BooksContext : IPuzzleContext
    {
        public BookHolder[] holders;
        public GameObject key;
    }
}