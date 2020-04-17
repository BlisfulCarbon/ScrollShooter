using System.Collections;
using System.Collections.Generic;
using ScrollShooter.Managers;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public float loweringForce = 1;

    private void OnMouseDown()
    {
        foreach (var gameObject in gameMenu.GetComponentsInChildren<Rigidbody2D>())
        {
            gameObject.AddForce(transform.up * (-1.0f * loweringForce), ForceMode2D.Impulse);
        }

        EventsManager.buttonToMenuPressed.Publish();
    }
}
