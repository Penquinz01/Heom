using UnityEngine;

using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
