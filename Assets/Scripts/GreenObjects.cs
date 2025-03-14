using UnityEngine;

public class GreenObjects : MonoBehaviour,IColor
{
    SpriteRenderer spriteRenderer;

    public void Initialize()
    {
        GameManager.Instance.RegisterGreen(this);
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameManager.Instance.Green;
    }

}
