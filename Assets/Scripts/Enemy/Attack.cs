using Unity.VisualScripting;
using UnityEngine;

public class Attack : IEnemyStates
{
    Enemy enemy;
    EnemyStateMAchine enemyStateMachine;
    float attackRange;
    float AttackTime;
    float nextAttack = 0;
    public Attack(Enemy enemy, EnemyStateMAchine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        attackRange = enemy.AttackRange;
        AttackTime = enemy.AttackTime;

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
        Collider2D[] cols = Physics2D.OverlapCircleAll(enemy.transform.position, attackRange, enemy.PlayerLayer);
        if (cols.Length == 0)
        {
            enemyStateMachine.Transition(enemyStateMachine.idle);
        }
        else
        {
            foreach (var col in cols)
            {
                if (col.CompareTag("Player"))
                {
                    PlayerMain player = col.GetComponent<PlayerMain>();
                    if (player != null && Time.time>nextAttack) { 
                        player.SwitchHurt();
                        nextAttack = Time.time + AttackTime;
                    }
                }
            }
        }
    }
}
