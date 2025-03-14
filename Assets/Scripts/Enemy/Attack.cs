using Unity.VisualScripting;
using UnityEngine;

public class Attack : IEnemyStates
{
    Enemy enemy;
    EnemyStateMAchine enemyStateMachine;
    float attackRange;
    float AttackTime;
    float nextAttack = 0;
    Vector3 offset;
    CharacterController2D controller;
    public Attack(Enemy enemy, EnemyStateMAchine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        attackRange = enemy.AttackRange;
        AttackTime = enemy.AttackTime;
        offset = enemy.AttackOffset;
        controller = enemy.GetComponent<CharacterController2D>();

    }
    public void Enter()
    {
        Debug.Log("Entered Attack");
    }

    public void Exit()
    {
        Debug.Log("Exited Attack");
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(enemy.transform.position + offset, attackRange, enemy.PlayerLayer);
        if (cols.Length == 0)
        {
            enemyStateMachine.Transition(enemyStateMachine.idle);
        }
        else
        {
            Collider2D col = cols[0];
            PlayerMain player = col.GetComponent<PlayerMain>();
            if (player != null && enemy.EnemyTypeObject == EnemyType.Archer) { 
                controller.SetMovement((player.transform.position -enemy.transform.position) );
            }
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + AttackTime;
                enemy.Attack();
            }
        }
    }
}
