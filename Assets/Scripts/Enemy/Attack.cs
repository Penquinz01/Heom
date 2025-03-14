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
    public Attack(Enemy enemy, EnemyStateMAchine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        attackRange = enemy.AttackRange;
        AttackTime = enemy.AttackTime;
        offset = enemy.AttackOffset;

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
            if(Time.time > nextAttack)
            {
                nextAttack = Time.time + AttackTime;
                enemy.Attack();
            }
        }
    }
}
