using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class PlayerExample : MonoBehaviour
    {
        [SerializeField] private Radio radio;
        [SerializeField] private Battery battery;
        
        private void Update()
        {
            //Donner
            if (Input.GetKeyDown(KeyCode.R))
            {
                radio.SetBattery(battery);
                battery = null;
                //print("Give Battery");
            }
        }
    }
}