using ScrollShooter.Events;
using ScrollShooter.Interfaces;

namespace ScrollShooter.Components
{
    public class EnemyHealth : Actor, Idamageable, Enemy
    {
        public int health;

        private void Update()
        {
            if (health <= 0)
            {
                EventManager.enemyDied.Publish();
                Destroy(this.gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            EventManager.enemyGetDamage.Publish();
            health -= damage;
        }
    }
}