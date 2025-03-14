using UnityEngine;

public class Chase : IEnemyStates
{
    Enemy enemy;
    EnemyStateMAchine enemyStateMachine;
    Rigidbody2D rb;
    CharacterController characterController;
    float attackRange;
    LayerMask playerLayer;
    public Chase(Enemy enemy, EnemyStateMAchine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        rb = enemy.GetComponent<Rigidbody2D>();
        characterController = enemy.GetComponent<CharacterController>();
        attackRange = enemy.AttackRange;
        playerLayer = enemy.PlayerLayer;
    }
    public void Enter()
    {
        Debug.Log("Entering Chase");
    }

    public void Exit()
    {
        Debug.Log("Exiting Chase");
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
        if (Physics2D.OverlapCircle(enemy.transform.position, attackRange, playerLayer))
        {
            Debug.Log("To Attack");
            enemyStateMachine.Transition(enemyStateMachine.attack);
        }
    }
}
