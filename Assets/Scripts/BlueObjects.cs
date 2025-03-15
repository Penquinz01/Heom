using UnityEngine;

public class BlueObjects : MonoBehaviour,IColor
{

    SpriteRenderer spriteRenderer;
    public void Initialize()
    {
        GameManager.Instance.RegisterBlue(this);
    }

    public void Remove()
    {
        GameManager.Instance.RemoveBlue(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameManager.Instance.Blue;
    }
    void OnDestroy() {
        Remove();
    }
}
