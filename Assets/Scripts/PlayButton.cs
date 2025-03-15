using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    SpriteRenderer sr;
    public Color init;
    public Color hover;
    public Color pressed;
    public string scene;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        sr.color = init;
        AudioManager audio = FindFirstObjectByType<AudioManager>();
        if (audio != null) {
            audio.Play("Theme");
        }
    }
    private void OnMouseOver() {
        sr.color = hover;
    }

    private void OnMouseExit() {
        sr.color = init;
    }

    private void OnMouseDown() {
        sr.color = pressed;
        SceneManager.LoadScene(scene);
    }
}
