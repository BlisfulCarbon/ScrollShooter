using ScrollShooter.Events;
using ScrollShooter.Managers;
using UnityEngine;

namespace ScrollShooter.Components
{
    public class StartButton : MonoBehaviour
    {
        public GameObject gameMenu;
        public float loweringForce = 1;

        private void OnMouseDown()
        {
            foreach (var gameObject in gameMenu.GetComponentsInChildren<Rigidbody2D>())
            {
                gameObject.AddForce(transform.up * (-1.0f * loweringForce), ForceMode2D.Impulse);
            }

            EventsManager.buttonStartPressed.Publish();
        }
    }
}