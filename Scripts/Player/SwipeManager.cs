using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public PlayerController playerMovement;  // Reference to the PlayerMovement script

    private Vector2 startTouchPosition;

    void Update()
    {
        DetectSwipe();
    }

    void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Vector2 currentTouchPosition = touch.position;
                Vector2 swipe = currentTouchPosition - startTouchPosition;

                // Check if the swipe distance is greater than the swipe threshold
                if (swipe.magnitude > playerMovement.swipeThreshold)
                {
                    playerMovement.OnSwipe(swipe);  // Call OnSwipe with the swipe vector
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // Optionally handle touch end event
                playerMovement.OnSwipe(Vector2.zero); // Stop movement on touch end
            }
        }
    }
}
