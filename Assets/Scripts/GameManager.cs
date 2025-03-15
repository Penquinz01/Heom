using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;


public enum ColorSelected
{
    Red, Green, Blue
}
public class GameManager : MonoBehaviour
{
    List<RedObjects> redObjects = new List<RedObjects>();
    List<GreenObjects> greenObjects = new List<GreenObjects>();
    List<BlueObjects> blueObjects = new List<BlueObjects>();
    [SerializeField]Color red;
    [SerializeField]Color blue;
    [SerializeField]Color green;
    public ColorSelected selected;
    CinemachineImpulseSource impulseSource;
    public static GameManager Instance { get; private set; }
    private Player control;
    int switchOption= 0;
    public event Action<int> OnOpengates;

    public Color Red { get => red;}
    public Color Green { get => green;}
    public Color Blue { get => blue; }
    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
        control = new Player();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        
        control.Hue.Switch.started += OnSwitch;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control.Enable();
        selected = ColorSelected.Red;
        //SetRed();
    }
    public void Opengates(int id)
    {
        OnOpengates?.Invoke(id);
    }

    private void OnSwitch(InputAction.CallbackContext context)
    {
        switchOption++;
        if (switchOption > 2)
        {
            switchOption = 0;
        }
        switch (switchOption)
        {
            case 0:SetRed(); selected = ColorSelected.Red; break;
            case 1: SetGreen(); selected = ColorSelected.Green;  break;
            case 2: SetBlue(); selected = ColorSelected.Blue;  break;
        }
        
    }

    private void SetBlue()
    {
        Camera.main.backgroundColor = blue;
        if (blueObjects.Count > 0)
        {
            foreach (BlueObjects item in blueObjects)
            {
                item.gameObject.SetActive(false);
            }
        }
        if (greenObjects.Count > 0)
        {
            foreach (GreenObjects item in greenObjects)
            {
                item.gameObject.SetActive(true);
            }
        }
        if (redObjects.Count > 0)
        {
            foreach (var item in redObjects)
            {
                item.gameObject.SetActive(true);
            }
        }
    }

       

    private void SetGreen()
    {
        Camera.main.backgroundColor = green;
        if (blueObjects.Count > 0)
        {
            foreach (BlueObjects item in blueObjects)
            {
                item.gameObject.SetActive(true);
            }
        }
        if (greenObjects.Count > 0)
        {
            foreach (GreenObjects item in greenObjects)
            {
                item.gameObject.SetActive(false);
            }
        }
        if (redObjects.Count > 0)
        {
            foreach (var item in redObjects)
            {
                item.gameObject.SetActive(true);
            }
        }
    }


    public void SetRed()
    {
        Camera.main.backgroundColor = red;
        if (blueObjects.Count > 0)
        {
            foreach (BlueObjects item in blueObjects)
            {
                item.gameObject.SetActive(true);
            }
        }
        if (greenObjects.Count > 0)
        {
            foreach (GreenObjects item in greenObjects)
            {
                item.gameObject.SetActive(true);
            }
        }
        if (redObjects.Count > 0)
        {
            foreach (var item in redObjects)
            {
                item.gameObject.SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    public  void RegisterRed(RedObjects red)
    {
        redObjects.Add(red);
    }
    public  void RegisterGreen(GreenObjects green)
    {
        greenObjects.Add(green);
    }
    public  void RegisterBlue(BlueObjects blue)
    {
        blueObjects.Add(blue);
    }
    public void RemoveGreen(GreenObjects green)
    {
        greenObjects.Remove(green);
    }
    public void RemoveRed(RedObjects red)
    {
        redObjects.Remove(red);
    }
    public void RemoveBlue(BlueObjects blue)
    {
        blueObjects.Remove(blue);
    }
    public Color GetColor(ColorSelected color) {
        switch (color)
        {
            case ColorSelected.Red:
                return red;
            case ColorSelected.Green:
                return green;
            case ColorSelected.Blue:
                return blue;
            default:
                return Color.white;
        }
    }
    public void CameraShake()
    {
        impulseSource.GenerateImpulse();
    }
    public void ReloadScene()
    {
        redObjects.Clear();
        blueObjects.Clear();
        greenObjects.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
