using ScrollShooter.Events;
using ScrollShooter.Interfaces;
using UnityEngine;

public class DestroyWhenCollisionEnemy : Actor
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Plyer trriger");
        if (other.GetComponent<Enemy>() == null)
            return;

        Debug.Log("It's enemy");
        EventAggregator.enemySmashIntoPlayer.Publish(this);
        Destroy(this.gameObject);
    }
}
