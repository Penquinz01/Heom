using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    CharacterController2D controller;
    PlayerInput input;
    Vector2 move;
    private bool isHurt = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = input.Movement;
        controller.SetMovement(move);
    }
    public void SwitchHurt()
    {

    }
}
