using UnityEngine;


public class ObjectSelector : MonoBehaviour
{
    [SerializeField] ColorSelected colorSelected = ColorSelected.Red;
    void Awake()
    {
        switch (colorSelected)
        {
            case ColorSelected.Red:
                {
                    if (gameObject.GetComponent<RedObjects>() == null) gameObject.AddComponent<RedObjects>();
                    break;
                }
            case ColorSelected.Green:
                {
                    if (gameObject.GetComponent<GreenObjects>() == null) gameObject.AddComponent<GreenObjects>();
                    break;
                }
            case ColorSelected.Blue:
                {
                    if (gameObject.GetComponent<BlueObjects>() == null) gameObject.AddComponent<BlueObjects>();
                    break;
                }
            default:
                break;
        }
        
    }
    private void Start()
    {
        IColor color = gameObject.GetComponent<IColor>();
        color.Initialize();
        GameManager.Instance.SetRed();
    }
}


