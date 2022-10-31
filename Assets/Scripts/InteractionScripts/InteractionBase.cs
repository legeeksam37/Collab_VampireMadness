using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    public ThirdPersonController player;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void Action()
    {
        if(player != null)
        {
            //DoAction
        }
    }
}
