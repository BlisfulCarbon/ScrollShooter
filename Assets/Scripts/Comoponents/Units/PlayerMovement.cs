using ScrollShooter.Config;
using ScrollShooter.Interfaces;
using UnityEngine;

namespace ScrollShooter.Components
{
    public class PlayerMovement : BaseComponent, IActor
    {
        [Header("Movement setting")] public float controlMultiplier;
        public bool isControlling;

        private Vector2 mouseEndPosition;
        private Vector2 mouseFirstPosition;

        private Vector2 playerStartPosiston;
        private Vector2 playerTargetPosition;

        private float xDiff;
        private float yDiff;
        

        private void Update()
        {
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

            var position = transform.position;
            var xPos = Mathf.Clamp(position.x, Constants.leftBoundaries, Constants.rightBoundaries);
            var yPos = Mathf.Clamp(position.y, Constants.downBoundaries, Constants.upBoundaries);
            position = new Vector3(xPos, yPos, 0);
            transform.position = position;
        }
    }
}