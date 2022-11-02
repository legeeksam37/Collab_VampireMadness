using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField]
    private Transform ennemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float TimeBetweenWaves = 5f;

    private float countdown = 2f;

    private int waveIndex = 0;


    public static int EnemiesAlive = 0;


    // Update is called once per frame
    void Update()
    {

        //if (EnemiesAlive > 0)
        //{
        //    Debug.Log(EnemiesAlive);
        //    return;
        //}

        if (countdown <= 0f)
        {
           StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {

        waveIndex++;

        for ( int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(5f);
            
        }

    }

    void SpawnEnemy()
    {
        Instantiate(ennemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawn");
        //EnemiesAlive++;
    }
}
