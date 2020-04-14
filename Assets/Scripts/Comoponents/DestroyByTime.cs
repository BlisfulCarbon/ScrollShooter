using UnityEngine;

namespace ScrollShooter.Components
{
    public class DestroyByTime : MonoBehaviour
    {
        public float destroyTime = 0;

        private void Start()
        {
            Destroy(this.gameObject, destroyTime);
        }
    }
}