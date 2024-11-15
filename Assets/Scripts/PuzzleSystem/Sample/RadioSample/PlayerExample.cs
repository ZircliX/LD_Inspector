using UnityEngine;

namespace PuzzleSystem.Sample
{
    public class PlayerExample : MonoBehaviour
    {
        private Battery battery;
        
        private void Update()
        {
            //Ramasser
            if (Input.GetKeyDown(KeyCode.E))
            {
                battery = RadioSetup.Instance.battery;
                //print("Take Battery");
            }

            //Donner
            if (Input.GetKeyDown(KeyCode.R))
            {
                RadioSetup.Instance.radio.SetBattery(battery);
                battery = null;
                //print("Give Battery");
            }
        }
    }
}