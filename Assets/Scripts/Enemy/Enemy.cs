using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterController2D))]

public class Enemy : MonoBehaviour
{
    EnemyStateMAchine enemyStateMachine;
    CharacterController2D controller;
    Rigidbody2D rb;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackRate = 1f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private Vector3 attackOffset = Vector2.zero;
    private bool isAttacking = false;
    private Animator anim;
    [SerializeField] Transform hitPos;
    [SerializeField]float hitRange = 0.1f;
    [SerializeField] private EnemyType enemyType = EnemyType.Swordsman;
    [SerializeField] private GameObject arrowPrefab = null;
    [SerializeField] private GameObject bloodEffect = null;
    [SerializeField] private GameObject head;
    [SerializeField] ColorSelected colorSelected = ColorSelected.Red;
    public EnemyType EnemyTypeObject { get { return enemyType; } }

    public float DetectionRange { get { return detectionRange; } }
    public float AttackRange { get { return attackRange; } }

    [SerializeField] private LayerMask playerLayer;
    public LayerMask PlayerLayer { get { return playerLayer; } }
    public float AttackTime { get { return attackRate; } }
    public Vector3 AttackOffset { get { return attackOffset; } }

    public int bloodCount;
    public float minSize, maxSize, minForce, maxForce;
    public GameObject bloodParticle;

    private void Awake()
    {
        enemyStateMachine = new EnemyStateMAchine(this);
        controller = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        switch (colorSelected)
        {
            case ColorSelected.Red:
                {
                    if (gameObject.GetComponent<RedObjects>() == null) gameObject.AddComponent<RedObjects>();
                    break;
                }
            case ColorSelected.Green:
                {
                    if (gameObject.GetComponent<GreenObjects>() == null) gameObject.AddComponent<GreenObjects>();
                    break;
                }
            case ColorSelected.Blue:
                {
                    if (gameObject.GetComponent<BlueObjects>() == null) gameObject.AddComponent<BlueObjects>();
                    break;
                }
        }
        

    }
    private void Start()
    {
        IColor color = gameObject.GetComponent<IColor>();
        color.Initialize();
        GameManager.Instance.SetRed();
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
    public void Die()
    {
        if (enemyType == EnemyType.Normal) { 
             GameObject header = Instantiate(head, transform.position + Vector3.up, Quaternion.identity);
             header.GetComponent<SpriteRenderer>().color = GameManager.Instance.GetColor(colorSelected);
        }
        GameManager.Instance.CameraShake();
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        IColor color = gameObject.GetComponent<IColor>();
        color.Remove();

        //hani code start
        for (int i = 0; i < bloodCount; i++) {
            float z = Random.Range(0f, Mathf.PI);
            float force = Random.Range(minForce, maxForce);
            float size = Random.Range(minSize, maxSize);

            Vector2 dir = new Vector2(Mathf.Cos(z), Mathf.Sin(z));
            var instance = Instantiate(bloodParticle, transform.position - (Vector3.forward), transform.rotation);

            instance.GetComponent<Rigidbody2D>().AddForce(dir * force);
            instance.transform.localScale = Vector3.one * size;
            Destroy(instance, 3f);
        }
        //hani code end

        Destroy(gameObject);
    }
}
public enum EnemyType
{
    Normal,
    Swordsman,
    Archer
}
