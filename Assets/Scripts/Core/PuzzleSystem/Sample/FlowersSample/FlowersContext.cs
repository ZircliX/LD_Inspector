using PuzzleSystem.Core;
using TMPro;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public struct FlowersContext : IPuzzleContext
    {
        public TMP_InputField codeInput;
        public Transform chest;
        public string code;
    }
}