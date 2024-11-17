using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class Tableau : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private GameObject door;
        
        public void PuzzleEnd(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();

            door.SetActive(false);
        }
    }
}