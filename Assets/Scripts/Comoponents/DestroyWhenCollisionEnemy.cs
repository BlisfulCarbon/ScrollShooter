using ScrollShooter.Events;
using ScrollShooter.Interfaces;
using UnityEngine;

public class DestroyWhenCollisionEnemy : Actor
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() == null)
            return;

        EventManager.enemySmashIntoPlayer.Publish();
        Destroy(this.gameObject);
    }
}
