using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    public float zoomSpeed = 0.01f; // Speed at which the object scales

    private Vector2 initialTouchPosition;
    private float initialScale;

    private void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch2.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch2.position;
                initialScale = transform.localScale.x;
            }
            else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                Vector2 currentTouchPosition = touch2.position;
                float touchDelta = Vector2.Distance(currentTouchPosition, initialTouchPosition);

                // Scale up when the pinch distance increases
                if (touchDelta > 0)
                {
                    float newScale = initialScale + touchDelta * zoomSpeed;
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                // Scale down when the pinch distance decreases
                else if (touchDelta < 0)
                {
                    float newScale = initialScale / Mathf.Abs(touchDelta) * zoomSpeed; // Corrected line
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
            }
        }
    }
}
