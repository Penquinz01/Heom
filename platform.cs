using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private int direction = 1;

    void Start()
    {
        // Ensure the platform starts at the 'down' position
        transform.position = down.position;
    }

    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        // Move the platform towards the target position
        Vector2 targetPosition = direction == 1 ? up.position : down.position;
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.deltaTime);
        rb.MovePosition(newPosition);

        // Check if the platform has reached the target position
        if (Vector2.Distance(rb.position, targetPosition) < 0.01f)
        {
            // Reverse the direction
            direction *= -1;
        }
    }
}
