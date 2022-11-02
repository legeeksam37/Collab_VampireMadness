using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Action(GameObject player)
    {
        if (player.GetComponent<ThirdPersonController>())
        {
           
        }
    }
}
