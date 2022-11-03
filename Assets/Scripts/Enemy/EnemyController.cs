using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform movePositionTransform;

    [SerializeField] private Animator anim;

    private WaveSpawner waveSpawner;

    private NavMeshAgent agent;

    private EnemyStats enemyStats;

    public float cooldown;

    private float distPlayer;

    public static bool isAttack;

    public static bool isMove;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        movePositionTransform = GameObject.Find(movePositionTransform.name).transform;
        distPlayer = Vector3.Distance(movePositionTransform.position, transform.position);
        enemyStats = GetComponent<EnemyStats>();
        waveSpawner = GameObject.FindWithTag("WaveManager").GetComponent<WaveSpawner>();
    }

    void Start()
    {
        isAttack = false;
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            agent.destination = movePositionTransform.position;
        }
        CheckCooldown();
        Death();
    }

    void Death()
    {
        if (enemyStats.PV <= 0)
        {
            if (waveSpawner.EnemiesAlive != 0)
            {
                waveSpawner.EnemiesAlive -= 1;
            }
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (cooldown <= 0 && isAttack == false)
            {
                PlayerStats stats = collision.gameObject.GetComponent<PlayerStats>();
                stats.PV -= enemyStats.damage;
                isAttack = true;
                cooldown = 1;
            }
        }
        return;
    }

    void CheckCooldown()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                isAttack = false;
            }
        }
    }
}
