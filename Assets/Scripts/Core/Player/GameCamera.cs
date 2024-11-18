using LTX.Singletons;
using UnityEngine;

namespace CyberEnigma.Core.Player
{
    public class GameCamera : MonoSingleton<GameCamera>
    {
        public static Vector3 Forward => Instance.transform.forward;
    }
}