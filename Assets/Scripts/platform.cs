using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private float y1;
    [SerializeField] private float y2;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    bool up = true;
    void Start()
    {
        rb.linearVelocityX = speed;
    }

    void Update()
    {
        if (transform.position.y < y1)
        {
            rb.linearVelocityY = 0f;
            rb.linearVelocityY = -speed;
        }
        if (transform.position.y < y2)
        {
            rb.linearVelocityX = 0;
            rb.linearVelocityX = speed;
        }
    }
