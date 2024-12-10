using PuzzleSystem.Core;
using TMPro;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class FlowersHandler : MonoBehaviour, IPuzzleHandler<FlowersContext>
    {
        [SerializeField] private MonoBehaviour[] flowersScripts;
        
        [SerializeField] private Transform chest;
        [SerializeField] private TMP_InputField codeInput;
        [SerializeField] private string code;
        
        private Flowers flowersPuzzle;
        
        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStopped += OnPuzzleStopped;
        }

        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStopped -= OnPuzzleStopped;
        }

        private void Start()
        {
            flowersPuzzle = new Flowers();
            PuzzleManager.Instance.StartPuzzle(flowersPuzzle, this);
        }
        
        private void OnPuzzleStopped(IPuzzleRunner puzzleRunner)
        {
            if (puzzleRunner.Puzzle is not Flowers) return;

            for (int i = 0; i < flowersScripts.Length; i++)
            {
                flowersScripts[i].enabled = false;
            }
        }
        
        public FlowersContext GetContext()
        {
            return new FlowersContext
            {
                codeInput = codeInput,
                chest = chest,
                code = code
            };
        }
    }
}