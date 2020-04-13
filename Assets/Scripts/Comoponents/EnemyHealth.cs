using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Actor
{
    public int health;
    private void Update()
    {
        if (health <= 0)
        {
            //TODO: pool object job
            EventAggregator.enemyDied.Publish(this);
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
