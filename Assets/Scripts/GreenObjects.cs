using UnityEngine;

public class GreenObjects : MonoBehaviour,IColor
{


    public void Initialize()
    {
        GameManager.Instance.RegisterGreen(this);
    }
    void Start()
    {
        Initialize();
    }

}
