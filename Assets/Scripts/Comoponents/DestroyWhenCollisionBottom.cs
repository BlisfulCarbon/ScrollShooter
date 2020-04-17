using UnityEngine;

namespace ScrollShooter.Components
{
    public class DestroyWhenCollisionBottom : BaseComponent
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Bottom>() != null)
                Destroy(this.gameObject);
        }
    }
}