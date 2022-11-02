using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent agent;

    public float cooldown;
    float lastAttack;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      agent.destination = movePositionTransform.position;
    }
}
