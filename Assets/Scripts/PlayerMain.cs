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
    private float initialVelJump =12f;
    private Animator anim;
    Rigidbody2D rb;
    [SerializeField]Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] float DashForce = 12f;
    private int health = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController2D>();
        input.Jump +=StartJump;
        input.Attack += PlayerAttack;
        controller._jumpForce = initialVelJump;
        rb = GetComponent<Rigidbody2D>();
    }

    private void PlayerAttack()
    {
        rb.AddForce(transform.right * DashForce, ForceMode2D.Impulse);
        anim.SetBool("isAttack",true);
    }
    public void EndAttack()
    {
        anim.SetBool("isAttack", false);
    } 
    public void OnHitFrame()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D col in cols)
        {
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Die();
            }
        }
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
        anim.SetFloat("isWalk",Mathf.Abs(rb.linearVelocityX));
        anim.SetBool("isGrounded", controller.isGrounded());
        if(controller.StartedJump == true)
        {
            controller.StartedJump = false;
            anim.SetTrigger("isJump");
        }
    }
    public void SwitchHurt()
    {
        isHurt = !isHurt;
        if (isHurt)
        {
            GameManager.Instance.CameraShake();
            Time.timeScale = 0f;
            StartCoroutine(HitFrame(hitStopTime));
            health--;
            if (health <= 0)
            {
                Die();
            }
        }
    }
    IEnumerator HitFrame(float waitSecond)
    {
        isHurt = true;
        anim.SetTrigger("isHurt");        
        yield return new WaitForSecondsRealtime(hitStopTime);
        Time.timeScale = 1f;
        isHurt = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void Die()
    {
        GameManager.Instance.CameraShake();
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.5f);
        input.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
