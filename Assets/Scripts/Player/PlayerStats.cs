using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player stats")]

    public float PV = 100f;
    
    public float Points = 0f;

    public float SpellsPower = 1f;

    public void UsePoints(float amount)
    {
        Points -= amount;
    }

    void Update(){
        Debug.Log(PV);
    }
}
