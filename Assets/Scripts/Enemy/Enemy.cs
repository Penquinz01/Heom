using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterController2D))]

public class Enemy : MonoBehaviour
{
    EnemyStateMAchine enemyStateMachine;
    CharacterController2D controller;
    Rigidbody2D rb;
    [SerializeField]private float attackRange = 1f;
    [SerializeField] private float attackRate = 1f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private Vector3 attackOffset = Vector2.zero;
    private bool isAttacking = false;
    private Animator anim;
    [SerializeField] Transform hitPos;
    [SerializeField]float hitRange = 0.1f;
    [SerializeField] private EnemyType enemyType = EnemyType.Swordsman;
    [SerializeField] private GameObject arrowPrefab = null;
    public EnemyType EnemyTypeObject { get { return enemyType; } }

    public float DetectionRange { get { return detectionRange; } }
    public float AttackRange { get { return attackRange; } }

    [SerializeField] private LayerMask playerLayer;
    public LayerMask PlayerLayer { get { return playerLayer; } }
    public float AttackTime { get { return attackRate; } }
    public Vector3 AttackOffset { get { return attackOffset; } }

    private void Awake()
    {
        enemyStateMachine = new EnemyStateMAchine(this);
        controller = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }
    // Update is called once per frame
    void Update()
    {
        enemyStateMachine.StateUpdate();
        if(enemyType != EnemyType.Archer)
        {
            anim.SetFloat("isWalking", Mathf.Abs(rb.linearVelocityX));
        }   
    }
    private void FixedUpdate()
    {
        enemyStateMachine.StateFixedUpdate();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position+attackOffset, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(hitPos.position, hitRange);
    }
    public void Attack()
    {
        isAttacking = true;

        anim.SetBool("isAttack", isAttacking);
        Debug.Log("Attacking");
    }
    public void EndAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttack", isAttacking);
    }
    
    public void HitFrame()
    {
        Collider2D col = Physics2D.OverlapCircle(hitPos.position, hitRange, playerLayer);
        if (col == null) return;
        switch (enemyType)
        {
            case EnemyType.Normal:
                col.GetComponent<PlayerMain>().SwitchHurt();
                break;
            case EnemyType.Archer:
                Debug.Log("Archer Attack");
                Instantiate(arrowPrefab, hitPos.position, hitPos.rotation);
                break;

            default:break;
        }
    }
}
public enum EnemyType
{
    Normal,
    Swordsman,
    Archer
}
