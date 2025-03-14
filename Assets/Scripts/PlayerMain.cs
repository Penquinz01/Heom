using System.Collections;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    CharacterController2D controller;
    PlayerInput input;
    Vector2 move;
    private bool isHurt = false;
    [SerializeField] float hitStopTime = 0.3f;
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
    IEnumerator HitFrame(float waitSecond)
    {
        isHurt = true;
        Time.timeScale = 0f;
        yield return new WaitForSeconds(waitSecond);
        Time.timeScale = 1f;
        isHurt = false;
    }
}
