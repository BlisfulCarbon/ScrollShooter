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

    void Start()
    {
        lifetimeSeconds = lifetime;
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0f, speed);
    }
    
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
