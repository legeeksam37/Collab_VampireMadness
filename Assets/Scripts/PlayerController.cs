using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
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


     void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "sphère")
        {
           if (Time.time > lastAttack)
           {
                lastAttack = Time.time;
                Debug.Log("Je te touche");
           }
          
        }
    }
}
