using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class Radio : MonoBehaviour
    {
        public Battery battery;
        public bool HasBattery => battery != null;

        [SerializeField]
        private AudioSource audioSource;

        public void SetBattery(Battery batteryToGive)
        {
            this.battery = batteryToGive;
        }

        public void PlayClip(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}