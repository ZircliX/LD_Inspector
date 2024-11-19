using DG.Tweening;
using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class Tableau : MonoBehaviour
    {
        public GameObject instructions;
        [SerializeField] private Transform tableau;
        public bool isActive;
        
        public void PuzzleEnd()
        {
            Vector3 targetPos = new Vector3(tableau.position.x, tableau.position.y, tableau.position.z + 2.5f);
            tableau.DOMove(targetPos, 1.5f);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && isActive)
            {
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