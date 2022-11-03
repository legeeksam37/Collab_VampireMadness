using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform movePositionTransform;

    [SerializeField] private Animator anim;

    [SerializeField] private AnimationClip clip;

    private WaveSpawner waveSpawner;

    private NavMeshAgent agent;

    private EnemyStats enemyStats;

    public float cooldown;

    public static bool isAttack;

    public static bool isMove;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyStats = GetComponent<EnemyStats>();
        movePositionTransform = GameObject.Find(movePositionTransform.name).transform;
        waveSpawner = GameObject.FindWithTag("WaveManager").GetComponent<WaveSpawner>();
    }

    void Start()
    {
        cooldown = 0;
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
        Debug.Log(cooldown);
        CheckCooldown();
        //Death();
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
                stats.TakeDamage(enemyStats.damage);
                anim.SetTrigger("Attack");
                isAttack = true;
                isMove = false;
                GetAnimClip();
            }
        }
        return;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.ResetTrigger("Attack");
            isMove = true;
            CheckCooldown();
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

    void GetAnimClip()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if(clip.name == "Attack")
            {
                cooldown = clip.length;
                break;
            }
        }
    }
}
