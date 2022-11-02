using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform movePositionTransform;

    [SerializeField] private Animator anim;

    private float distPlayer;

    private NavMeshAgent agent;

    public float cooldown;

    public static bool isMove = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        movePositionTransform = GameObject.Find(movePositionTransform.name).transform;
        distPlayer = Vector3.Distance(movePositionTransform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    { 
        if (isMove == true)
        {
            agent.destination = movePositionTransform.position;
            distPlayer = Vector3.Distance(movePositionTransform.position, transform.position);
        }

        anim.ResetTrigger("Attack");

        if (distPlayer <= 1){
            anim.SetTrigger("Attack");
         }
    }
}
