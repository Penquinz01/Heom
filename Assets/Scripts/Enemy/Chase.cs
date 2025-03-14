using UnityEngine;

public class Chase : IEnemyStates
{
    Enemy enemy;
    EnemyStateMAchine enemyStateMachine;
    Rigidbody2D rb;
    CharacterController2D characterController;
    float attackRange;
    LayerMask playerLayer;
    float detectionRange;
    public Chase(Enemy enemy, EnemyStateMAchine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        rb = enemy.GetComponent<Rigidbody2D>();
        characterController = enemy.GetComponent<CharacterController2D>();
        attackRange = enemy.AttackRange;
        playerLayer = enemy.PlayerLayer;
        detectionRange = enemy.DetectionRange;
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
            return;
        }
        Collider2D[] cols =Physics2D.OverlapCircleAll(enemy.transform.position, detectionRange, playerLayer);
        if (cols.Length>0)
        {
            foreach(var col in cols)
            {
                PlayerMain player = col.GetComponent<PlayerMain>();
                if (player != null)
                {
                    Vector2 dir = (player.transform.position - enemy.transform.position).normalized;
                    RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, dir, detectionRange * 2, playerLayer);
                    if (hit.collider != null)
                    {
                        characterController.SetMovement(dir);
                    }
                }
            }
        }
        else
        {
            characterController.SetMovement(Vector2.zero);
            enemyStateMachine.Transition(enemyStateMachine.idle);
        }
    }
}
