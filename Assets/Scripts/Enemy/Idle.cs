using UnityEngine;

public class Idle : IEnemyStates
{
    Enemy enemy;
    EnemyStateMAchine enemyStateMachine;
    float detectionRadius;
    LayerMask playerLayer;
    public Idle(Enemy enemy,EnemyStateMAchine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        detectionRadius = enemy.DetectionRange;
        playerLayer = enemy.PlayerLayer;
    }
    public void Enter()
    {
        Debug.Log("Entered Idle");
    }

    public void Exit()
    {
        Debug.Log("Exited Idle");
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {

        if (Physics2D.OverlapCircle(enemy.transform.position, detectionRadius, playerLayer))
        {
            enemyStateMachine.Transition(enemyStateMachine.chase);
        }
    }
}
