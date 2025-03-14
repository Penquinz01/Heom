using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour
{
    private Player _input;
    public Vector2 Movement { get; private set; }
    public event Action Attack;
    public event Action Jump;

    private void Awake()
    {
        _input = new Player();
        _input.Enable();
        _input.PlayerActions.Movement.performed += MovePerformed;
        _input.PlayerActions.Attack.performed += AttackPerformed;
        _input.PlayerActions.Jump.performed += JumpPerformed;
        _input.PlayerActions.Movement.canceled += MoveStopped;
    }

    private void MoveStopped(InputAction.CallbackContext context)
    {
        Movement = Vector2.zero;
    }

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        Attack?.Invoke();
    }

    private void AttackPerformed(InputAction.CallbackContext context)
    {
        Jump?.Invoke();
    }

    private void MovePerformed(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    private void OnEnable()
    {
        _input.Enable();
    }
   
}
