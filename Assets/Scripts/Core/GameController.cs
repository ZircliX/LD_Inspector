using LTX.ChanneledProperties;
using UnityEngine;

namespace CyberEnigma.Core
{
    public static class GameController
    {
        //initialisé les properties
        public static PrioritisedProperty<bool> CursorVisibility { get; private set; }
        public static PrioritisedProperty<CursorLockMode> CursorLockMode { get; private set; }
        
        public static PrioritisedProperty<float> TimeScale { get; private set; }
        
        //Code exécuter avant le LoadScene
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            //Creation
            CursorVisibility = new PrioritisedProperty<bool>(true);
            CursorLockMode = new PrioritisedProperty<CursorLockMode>(UnityEngine.CursorLockMode.None);

            TimeScale = new PrioritisedProperty<float>(1f);

            //Notification quand la valeur change
            CursorVisibility.AddOnValueChangeCallback(UpdateCursorVisibility, true);
            CursorLockMode.AddOnValueChangeCallback(UpdateCursorLockMode, true);
            
            TimeScale.AddOnValueChangeCallback(UpdateTimeScale, true);
        }
        
        //Fonction pour le UpdateCursorLockMode
        private static void UpdateCursorLockMode(CursorLockMode lockMode)
        {
            Cursor.lockState = lockMode;
        }
        
        //Fonction pour le UpdateCursorVisibility
        private static void UpdateCursorVisibility(bool isVisible)
        {
            Cursor.visible = isVisible;
        }

        private static void UpdateTimeScale(float newScale)
        {
            Time.timeScale = newScale;
        }
    }
}