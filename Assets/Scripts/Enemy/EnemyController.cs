using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform movePositionTransform;

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
 
    }
}
