using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform movePositionTransform;

    [SerializeField] public CapsuleCollider cap;

    [SerializeField] private Animator anim;

    private NavMeshAgent agent;

    public float cooldown;

    public static bool isMove = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        movePositionTransform = GameObject.Find(movePositionTransform.name).transform;
    }

    // Update is called once per frame
    void Update()
    { 
        if (isMove == true)
        {
            agent.destination = movePositionTransform.position;
        }
        if (Vector3.Distance(movePositionTransform.position, transform.position) <= 1){
            CollisionEnter();
        }

    }

    void CollisionEnter()
    {
        anim.SetTrigger("Attack");
        movePositionTransform.GetComponent<PlayerStats>().PV -= 15;
        isMove = false;
    }

    void OnTriggerEnter(Collider col){
        if (col.tag == "player"){
            Debug.Log("hello");
        }

        if (col.tag == "untagged"){
            cap.isTrigger = true;
            Debug.Log("hello");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){
            anim.ResetTrigger("Attack");
            isMove = true;
        }
    }

}
