using ScrollShooter.Interfaces;
using ScrollShooter.Managers;
using UnityEngine;

public class DestroyWhenCollisionEnemy : BaseComponent
{
    public GameObject impactParticle;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() == null)
            return;

        EventsManager.enemySmashIntoPlayer.Publish();
        Instantiate(impactParticle, transform.position, Quaternion.identity);
        // Destroy(this.gameObject);
    }
}
