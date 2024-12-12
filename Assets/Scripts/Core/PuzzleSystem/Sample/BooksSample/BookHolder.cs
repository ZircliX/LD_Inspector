using Core.Detection;
using CyberEnigma.Core.Inventory.Core.Data;
using DG.Tweening;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class BookHolder : MonoBehaviour
    {
        [SerializeField] private ItemGroup correctType;
        [SerializeField] private Transform target;
        private Collectable currentItem;

        public bool IsCorrectItem()
        {
            if (currentItem == null) return false;

            return correctType == currentItem.inventoryElement.itemGroup;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Book")) return;
            
            if (other.transform.parent.TryGetComponent(out Collectable comp))
            {
                currentItem = comp;
                currentItem.GetComponent<Rigidbody>().isKinematic = true;

                currentItem.transform.DOMove(target.position, 2f);
                currentItem.transform.LookAt(GameObject.FindWithTag("Player").transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Book")) return;
            
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem = null;
        }
    }
}