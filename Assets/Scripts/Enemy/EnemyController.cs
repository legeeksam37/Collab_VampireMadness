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


    public static bool isMove;

    private bool canMove;
    private bool canAttack;
    private bool inAttack;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyStats = GetComponent<EnemyStats>();
        movePositionTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        cooldown = 0;

        canAttack = true;
        inAttack = false;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            agent.destination = movePositionTransform.position;
        }
        CheckCooldown();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(canAttack)
            {
                nearestPlayer = collision.gameObject.GetComponent<PlayerStats>();
                StartCoroutine(Attack());
            }
        }
        
        return;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nearestPlayer = null;
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
                canAttack = true;
                inAttack = false;
                canMove = true;
                anim.ResetTrigger("Attack");
            }
        }
    }

    void SetCooldown()
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
    }

    IEnumerator Attack()
    {
        anim.SetTrigger("Attack");
        canAttack = false;
        inAttack = true;
        canMove = false;
        SetCooldown();
        Debug.Log("Attaque !");

        yield return new WaitForSeconds(0.3f);

        anim.ResetTrigger("Attack");
    }
}
