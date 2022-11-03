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

    private NavMeshAgent agent;

    private EnemyStats enemyStats;

    PlayerStats nearestPlayer;

    public float cooldown;

    public static bool isAttack;

    public static bool isMove;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyStats = GetComponent<EnemyStats>();
        movePositionTransform = GameObject.Find(movePositionTransform.name).transform;
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
        CheckCooldown();
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (cooldown <= 0 && isAttack == false)
            {
                nearestPlayer = collision.gameObject.GetComponent<PlayerStats>();
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
            nearestPlayer = null;
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
                isMove = true;
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

    public void DealDamage()
    {
        if(nearestPlayer != null)
        {
            nearestPlayer.TakeDamage(enemyStats.damage);
        }
        else
        {
            Debug.Log("Player trop loin");
        }
    }
}
