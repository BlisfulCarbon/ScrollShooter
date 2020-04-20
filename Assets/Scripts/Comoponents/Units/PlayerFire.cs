using ScrollShooter.Interfaces;
using UnityEngine;

namespace ScrollShooter.Components
{
    public class PlayerFire : BaseComponent, IActor
    {
        [Header("Fire Variables")] 
        public Transform firePoint;
        public GameObject weapon;
        public float fireWait = 3f;
        private float fireWaitSeconds;

        private void Start()
        {
            fireWaitSeconds = fireWait;
        }

        private void Update()
        {
            fireWaitSeconds -= Time.deltaTime;
            if (fireWaitSeconds <= 0)
            {
                Fire();
                fireWaitSeconds = fireWait;
            }
        }

        public void Fire()
        {
            Instantiate(weapon, firePoint.position, Quaternion.identity);
        }
    }
}