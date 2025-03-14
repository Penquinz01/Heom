using UnityEngine;

public class RedObjects : MonoBehaviour, IColor
{
    SpriteRenderer spriteRenderer;
    public void Initialize()
    {
        GameManager.Instance.RegisterRed(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = GameManager.Instance.Red;
    }
    // Update is called once per frame

}

