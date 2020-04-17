using ScrollShooter.Interfaces;
using ScrollShooter.Managers;

namespace ScrollShooter.Components
{
    public class EnemyHealth : BaseComponent, Idamageable, Enemy
    {
        public int health;

        private void Update()
        {
            if (health <= 0)
            {
                EventsManager.enemyDied.Publish();
                Destroy(this.gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            EventsManager.enemyGetDamage.Publish();
            health -= damage;
        }
    }
}