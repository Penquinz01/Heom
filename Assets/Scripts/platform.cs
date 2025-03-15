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
        
    }

    // Update is called once per frame
    void Update()
    {
        up = transform.position.y < y1 ;
        if (up)
        {
            Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, y1), speed);
        }
        else
        {
            Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, y2), speed);
        }

    }
}
