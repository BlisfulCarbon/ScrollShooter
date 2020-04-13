using UnityEngine;

public class Bulet : MonoBehaviour
{
    [Header("Movement Variables")] 
    public float speed;
    private Rigidbody2D rigidbody;
    
    [Header("Damage")]
    public int damage;
    public GameObject impactParticle;

    private void Start()
    {
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
}
