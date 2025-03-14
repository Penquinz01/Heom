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
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyStateMachine.StateUpdate();
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
    }
}
