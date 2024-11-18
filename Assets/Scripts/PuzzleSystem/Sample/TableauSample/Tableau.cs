using DG.Tweening;
using TMPro;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class Tableau : MonoBehaviour
    {
        public GameObject instructions;
        public bool isActive;
        
        public void PuzzleEnd()
        {
            Vector3 targetPos = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
            transform.DOMove(targetPos, 1.5f);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && isActive)
            {
                Debug.Log("In Area");
                instructions.SetActive(true);
                
                TableauPlayer player = other.GetComponent<TableauPlayer>();
                player.isInArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && isActive)
            {
                instructions.SetActive(false);
                
                TableauPlayer player = other.GetComponent<TableauPlayer>();
                player.isInArea = false;
            }
        }
    }
}