using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement setting")]
    public float controlMultiplier;
    public bool isControlling;

    private Vector2 mouseEndPosition;
    private Vector2 mouseFirstPosition;

    private Vector2 playerStartPosiston;
    private Vector2 playerTargetPosition;

    private float xDiff;
    private float yDiff;

    private void Update()
    {
        // TODO: Move to controller
        if (Input.GetMouseButtonDown(0))
        {
            isControlling = true;
            mouseFirstPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerStartPosiston = transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isControlling = false;
        }

        if (isControlling)
        {
            mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            xDiff = (mouseEndPosition.x - mouseFirstPosition.x) * controlMultiplier;
            yDiff = (mouseEndPosition.y - mouseFirstPosition.y) * controlMultiplier;
            playerTargetPosition = new Vector2(playerStartPosiston.x + xDiff, playerStartPosiston.y + yDiff);
            transform.position = Vector2.Lerp(transform.position, playerTargetPosition, .2f);
        }

        // TODO: Get clamp camera
        var xPos = Mathf.Clamp(transform.position.x, -1f, 1f);
        var yPos = Mathf.Clamp(transform.position.y, -1.8f, 1.8f);
        transform.position = new Vector3(xPos, yPos, 0);
    }
}