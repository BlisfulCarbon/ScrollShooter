using ScrollShooter.Events;
using UnityEngine;
using ScrollShooter.Interfaces;

namespace ScrollShooter.Components
{
    public class Bulet : Actor
    {
        [Header("Movement Variables")] public float speed;
        private Rigidbody2D rigidbody;

        [Header("Damage")] public int damage;
        public GameObject impactParticle;

        private void Start()
        {
            EventAggregator.TakeShot.Publish(this);
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2(0f, speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.GetComponent<Idamageable>();
            if (enemy == null) return;

            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Instantiate(impactParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}