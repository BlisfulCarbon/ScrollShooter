using UnityEngine;

namespace ScrollShooter.Config
{
    public class Constants : MonoBehaviour
    {
        // TODO: Show from inspector
        [Header("Default initialization game parameters")]
        public const float timeForStartingGame = 3.3f;
        
        
        public static readonly float upBoundaries = 5.8f;
        public static readonly float downBoundaries = 2.2f;
        public static readonly float leftBoundaries = 1.5f;
        public static readonly float rightBoundaries = 3.5f;
    }
}