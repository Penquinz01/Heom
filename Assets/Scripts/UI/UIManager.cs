using UnityEngine;
using UnityEngine.UI;   

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Text healthText;
    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
    }
    void Start()
    {
        healthText.text = "3";
    }

    public void UpdateText(int hp)
    {
        healthText.text = hp.ToString();
    }
    public void ExitApp()
    {
        Application.Quit(); 
    }
}
