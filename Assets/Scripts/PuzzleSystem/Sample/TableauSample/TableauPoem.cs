using Inventory.Core.Data;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class TableauPoem : MonoBehaviour
    {
        [field : SerializeField] public InventoryElement InventoryElement { get; private set; }
        [SerializeField] private TableauPuzzleHandler puzzleHandler;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Start Puzzle");
                
                Inventory.Core.Inventory inventory = other.GetComponent<Inventory.Core.Inventory>();
                inventory.AddItem(InventoryElement);
                
                puzzleHandler.StartPuzzle();
                Destroy(gameObject);
            }
        }
    }
}