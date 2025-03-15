using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public GameObject enemy;
    void Update()
    {
        if (enemy == null) {
            SceneManager.LoadScene("Area51");
        }
    }
}
