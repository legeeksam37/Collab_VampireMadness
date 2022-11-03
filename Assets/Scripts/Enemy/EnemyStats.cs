using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]

    public float PV = 100f;

    public float damage = 0f;

    void Start()
    {
        AssignDamage();
    }
    void AssignDamage()
    {
        if (gameObject.tag == "Zombie")
        {
            damage = 10f;
        }
        if (gameObject.tag == "Vampire")
        {
            damage = 20f;
        }
    }
}
