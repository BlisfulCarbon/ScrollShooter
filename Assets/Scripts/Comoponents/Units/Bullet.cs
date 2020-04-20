using ScrollShooter.Events;
using ScrollShooter.Interfaces;
using UnityEngine;

namespace ScrollShooter.Components
{
    public class Bullet : BaseComponent, IActor
    {
        [Header("Movement Variables")] public float speed;
        private Rigidbody2D _body;

        [Header("Damage")] public int damage;
        public GameObject impactParticle;

        private void Start()
        {
            EventsAggregator.TakeShot.Publish();
            _body = GetComponent<Rigidbody2D>();
            _body.velocity = new Vector2(0f, speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.GetComponent<IDamageable>();
            if (enemy == null) return;

            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Instantiate(impactParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}