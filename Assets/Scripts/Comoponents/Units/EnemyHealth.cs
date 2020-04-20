using ScrollShooter.Events;
using ScrollShooter.Interfaces;

namespace ScrollShooter.Components
{
    public class EnemyHealth : BaseComponent, IActor, IDamageable, IEnemy
    {
        public int health;

        private void Update()
        {
            if (health <= 0)
            {
                EventsAggregator.enemyDied.Publish();
                Destroy(this.gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            EventsAggregator.enemyGetDamage.Publish();
            health -= damage;
        }
    }
}