using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform movePositionTransform;

    [SerializeField] public CapsuleCollider cap;

    [SerializeField] private Animator anim;

    private WaveSpawner waveSpawner;

    private NavMeshAgent agent;

    public float cooldown;

    private float damage;

    public float life;

    public static bool isMove = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        movePositionTransform = GameObject.Find(movePositionTransform.name).transform;
        waveSpawner = GameObject.FindWithTag("WaveManager").GetComponent<WaveSpawner>();
        life = 100;
    }

    // Update is called once per frame
    void Update()
    { 
        if (isMove == true)
        {
            agent.destination = movePositionTransform.position;
        }
        if (Vector3.Distance(movePositionTransform.position, transform.position) <= 1){
            //CollisionEnter();
        }
        Death();

    }

    //void CollisionEnter()
    //{
    //    anim.SetTrigger("Attack");
    //    movePositionTransform.GetComponent<PlayerStats>().PV -= 15;
    //    isMove = false;
    //}

    void Death()
    {
        if(life <= 0)
        {
            if(waveSpawner.EnemiesAlive != 0)
            {
                waveSpawner.EnemiesAlive -= 1;
            }    
            Destroy(gameObject);
        }
    }

    //void OnTriggerEnter(Collider col){
    //    if (col.tag == "player"){
    //        Debug.Log("hello");
    //    }

    //    if (col.tag == "untagged"){
    //        cap.isTrigger = true;
    //        Debug.Log("hello");
    //    }
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player"){
    //        anim.ResetTrigger("Attack");
    //        isMove = true;
    //    }
    //}

}
