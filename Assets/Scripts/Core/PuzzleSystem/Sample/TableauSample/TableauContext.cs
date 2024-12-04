using PuzzleSystem.Core;
using TMPro;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public struct TableauContext : IPuzzleContext
    {
        public TMP_InputField codeInput;
        public Transform tableau;
        public string code;
    }
}