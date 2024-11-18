using UnityEngine;

public class RandomPatrol : MonoBehaviour
{
    public Vector2 centrePoint; // Central point of the patrol area
    public float patrolRangeX = 4.5f; // Horizontal range
    public float patrolRangeY = 3.5f; // Vertical range
    public float speed = 2f; // Movement speed

    private Vector2 targetPosition;
    private Camera cam;

    void Start()
    {
        cam = Camera.main; // Reference to the main camera
        SetNewRandomTarget();
    }

    void Update()
    {
        // Move toward the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Clamp position to ensure it stays within the screen boundaries
        Vector3 screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);
        transform.position = new Vector2(clampedX, clampedY);

        // Check if the target position has been reached
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewRandomTarget();
        }
    }

    void SetNewRandomTarget()
    {
        Vector3 screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        targetPosition = new Vector2(
            Random.Range(Mathf.Max(centrePoint.x - patrolRangeX, -screenBounds.x), Mathf.Min(centrePoint.x + patrolRangeX, screenBounds.x)),
            Random.Range(Mathf.Max(centrePoint.y - patrolRangeY, -screenBounds.y), Mathf.Min(centrePoint.y + patrolRangeY, screenBounds.y))
        );

        // Debug.Log("New Target Position: " + targetPosition);
    }
}
