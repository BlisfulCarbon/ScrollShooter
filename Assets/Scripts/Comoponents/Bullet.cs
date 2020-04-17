using UnityEngine;
using ScrollShooter.Interfaces;
using ScrollShooter.Managers;

namespace ScrollShooter.Components
{
    public class Bullet : BaseComponent
    {
        [Header("Movement Variables")] public float speed;
        private Rigidbody2D  _body;

        [Header("Damage")] public int damage;
        public GameObject impactParticle;

        private void Start()
        {
            EventsManager.TakeShot.Publish();
            _body = GetComponent<Rigidbody2D>();
            _body.velocity = new Vector2(0f, speed);
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