using UnityEngine;

<<<<<<< Updated upstream
public class platform : MonoBehaviour {
=======
public class platform: MonoBehaviour
{
>>>>>>> Stashed changes
    [SerializeField] private float y1;
    [SerializeField] private float y2;
    [SerializeField] private float speed;
<<<<<<< Updated upstream
    bool up = true;
    void Start() {
        rb.linearVelocityX = speed;
    }

    void Update() {
        if (transform.position.y < y1) {
            rb.linearVelocityY = 0f;
            rb.linearVelocityY = -speed;
        }
        if (transform.position.y < y2) {
            rb.linearVelocityX = 0;
            rb.linearVelocityX = speed;
=======

    private bool up = true;

    private void Start()
    {
    }

    private void Update()
    {
        if (up)
        {
            if (transform.position.y < y1)
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            else
                up = false;
        }
        else
        {
            if (transform.position.y > y2)
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            else
                up = true;
>>>>>>> Stashed changes
        }
            
    }
}
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
