using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float Velocity;
    private Rigidbody2D rb;
    [SerializeField] float DestroyTime = 2f;
    private float initTime = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * Velocity, ForceMode2D.Impulse);
        initTime = Time.time+DestroyTime;
    }
    private void Update()
    {
        if (Time.time > initTime)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMain player = collision.gameObject.GetComponent<PlayerMain>();
            player.SwitchHurt();
        }
        Destroy(gameObject);
    }
}
