using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float _movementSpeed = 5f;
    public float _jumpForce = 10f;
    private bool isRight = true;
    [SerializeField] LayerMask Ground;
    private float defaultGravityScale;
    [SerializeField] float jumpMultiplier = 2.5f;
    public bool StartedJump=false;
    public Vector2 _movement { private get; set; }
    public float speedY { get => _rigidbody2D.linearVelocityY; }
    bool lastGround = false;
    
    float initialVelJump;
    [SerializeField] float rayLength = 1f;
    [SerializeField] float CoyoteTime = 0.2f;
    float lastGroundTime;

    private void Start()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        defaultGravityScale = _rigidbody2D.gravityScale;
        
    }
    public void SetMovement(Vector2 vec)
    {
        _movement = vec;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        if (!isGrounded() && lastGround)
        {
            lastGround = true;
            lastGroundTime = Time.time;
        }
        else if (isGrounded())
        {
            lastGround = true;
        }
        _rigidbody2D.gravityScale = _rigidbody2D.linearVelocity.y < 0 ? defaultGravityScale * jumpMultiplier : defaultGravityScale;
    }

    private void Move()
    {
        _rigidbody2D.linearVelocity = new Vector2(_movement.x * _movementSpeed, _rigidbody2D.linearVelocityY);
        if ((isRight && _movement.x < 0) || (!isRight && _movement.x > 0)) Flip();
    }
    void Flip()
    {
        isRight = !isRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void Jump()
    {
        if (isGrounded()||(!isGrounded() && Time.time < lastGroundTime + CoyoteTime))
        {
            StartedJump = true;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, Ground);
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }
}
