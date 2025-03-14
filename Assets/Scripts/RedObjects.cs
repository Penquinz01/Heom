using UnityEngine;

public class RedObjects : MonoBehaviour, IColor
{

    public void Initialize()
    {
        GameManager.Instance.RegisterRed(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }
    // Update is called once per frame

}

