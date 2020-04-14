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
                EventAggregator.enemyDied.Publish(this);
                Destroy(this.gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            EventAggregator.enemyGetDamage.Publish(this);
            health -= damage;
        }
    }
}