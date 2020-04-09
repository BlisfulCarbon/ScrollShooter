using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    [Header("Movement Variables")] 
    public float speed;
    private Rigidbody2D rigidbody;

    [Header("Lifetime")]
    public float lifetime;
    private float lifetimeSeconds;
    
    [Header("Damage")]
    public int damage;
    public GameObject impactParticle;

    private void Start()
    {
        lifetimeSeconds = lifetime;
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0f, speed);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<EnemyHealth>();
        if (enemy == null) return;
        other.GetComponent<EnemyHealth>().TakeDamage(damage);
        //TODO: hide impact
        Instantiate(impactParticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
