using ScrollShooter.Events;
using UnityEngine;

namespace ScrollShooter.Components
{
    public class ReturnToMenu : MonoBehaviour
    {
        public GameObject gameMenu;
        public float loweringForce = 1;

        private void OnMouseDown()
        {
            foreach (var gameObject in gameMenu.GetComponentsInChildren<Rigidbody2D>())
                gameObject.AddForce(transform.up * (-1.0f * loweringForce), ForceMode2D.Impulse);

            EventsAggregator.buttonToMenuPressed.Publish();
        }
    }
}