using System;
using System.Collections;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    CharacterController2D controller;
    PlayerInput input;
    Vector2 move;
    private bool isHurt = false;
    [SerializeField] float hitStopTime = 0.3f;
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] float maxHeight = 1.5f;
    [SerializeField] float maxRange = 2f;
    public float initialVelJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxRange = Mathf.Abs(left.position.x - right.position.x);
        maxHeight = top.position.y - bottom.position.y;
        input = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController2D>();
        input.Jump +=StartJump;
        initialVelJump = (2 * maxHeight * controller._movementSpeed) / (maxRange / 2);
        float gravityValue = (-2 * maxHeight * controller._movementSpeed * controller._movementSpeed) / (maxRange * maxRange / 4);
        Physics2D.gravity = new Vector2(0, gravityValue);
        controller._jumpForce = initialVelJump;
        Debug.Log("Initial Jump Velocity: " + initialVelJump);
        Debug.Log("Gravity Value: " + gravityValue);
    }

    private void StartJump()
    {
        controller.Jump();
    }

    // Update is called once per frame
    void Update()
    {
        move = input.Movement;
        controller.SetMovement(move);
    }
    public void SwitchHurt()
    {
        Debug.Log("Hurt");
        isHurt = !isHurt;
        if (isHurt)
        {
            Time.timeScale = 0f;
            StartCoroutine(HitFrame(hitStopTime));
        }
    }
    IEnumerator HitFrame(float waitSecond)
    {
        isHurt = true;
        
        yield return new WaitForSecondsRealtime(hitStopTime);
        Time.timeScale = 1f;
        isHurt = false;
    }
}
