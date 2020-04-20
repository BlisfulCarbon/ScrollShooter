using ScrollShooter.Components;
using ScrollShooter.Events;
using ScrollShooter.Interfaces;
using UnityEngine;

public class DestroyWhenCollisionEnemy : BaseComponent
{
    public GameObject impactParticle;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IEnemy>() == null)
            return;

        EventsAggregator.enemySmashIntoPlayer.Publish();
        Instantiate(impactParticle, transform.position, Quaternion.identity);
        // Destroy(this.gameObject);
    }
}
