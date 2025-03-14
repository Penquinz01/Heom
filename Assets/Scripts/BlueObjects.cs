using UnityEngine;

public class BlueObjects : MonoBehaviour,IColor
{


    public void Initialize()
    {
        GameManager.Instance.RegisterBlue(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }  
}
