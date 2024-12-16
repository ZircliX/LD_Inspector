using Core.Detection;
using CyberEnigma.Core.Inventory.Core.Data;
using UnityEngine;
using DG.Tweening;

namespace PuzzleSystem.Sample
{
    public class ChestHolder : MonoBehaviour
    {
        [SerializeField] private string correctTag;
        [SerializeField] private ItemGroup[] correctType;
        [SerializeField] private Transform target;
        private Collectable[] currentItems;

        public bool IsCorrectItem()
        {
            if (currentItems == null || currentItems.Length != correctType.Length) return false;

            foreach (ItemGroup type in correctType)
            {
                bool hasType = false;
                foreach (Collectable item in currentItems)
                {
                    if (item.inventoryElement.itemGroup == type)
                    {
                        hasType = true;
                        break;
                    }
                }
                if (!hasType) return false;
            }
            return true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(correctTag)) return;
            
            if (other.transform.parent.TryGetComponent(out Collectable comp))
            {
                if (currentItems == null) currentItems = new Collectable[correctType.Length];
                for (int i = 0; i < currentItems.Length; i++)
                {
                    if (currentItems[i] == null)
                    {
                        currentItems[i] = comp;
                        comp.GetComponent<Rigidbody>().isKinematic = true;
                        comp.transform.DOMove(target.position, 2f);
                        comp.transform.LookAt(GameObject.FindWithTag("Player").transform);
                        break;
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(correctTag) || currentItems == null) return;
                    
            for (int i = 0; i < currentItems.Length; i++)
            {
                if (currentItems[i] != null)
                {
                    currentItems[i].GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            currentItems = null;
        }
    }
}