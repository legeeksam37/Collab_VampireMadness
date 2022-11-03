using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]

    public float PV = 100f;

    public float damage = 0f;

    [SerializeField]
    int pointsOnDeath;

    private WaveSpawner waveSpawner;

    void Start()
    {
        waveSpawner = GameObject.FindWithTag("WaveManager").GetComponent<WaveSpawner>();
    }


    public void TakeDamage(float damage, PlayerStats playerDealDamage)
    {
        PV -= damage;

        if (PV <= 0)
        {
            if (waveSpawner.EnemiesAlive != 0)
            {
                waveSpawner.EnemiesAlive -= 1;
            }

            playerDealDamage.AddPoints(pointsOnDeath);
            Destroy(gameObject);
        }
    }
}
