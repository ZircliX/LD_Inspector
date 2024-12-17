using PuzzleSystem.Core;
using UnityEngine;

namespace PuzzleSystem.Sample.Core.PuzzleSystem.Sample
{
    public class PlaySound : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        
        private void OnEnable()
        {
            PuzzleManager.Instance.OnPuzzleStopped += OnPlaySound;
        }
        
        private void OnDisable()
        {
            PuzzleManager.Instance.OnPuzzleStopped -= OnPlaySound;
        }

        private void OnPlaySound(IPuzzleRunner obj)
        {
            AudioSource.PlayClipAtPoint(clip, GameObject.FindWithTag("Player").transform.position);
        }
    }
}