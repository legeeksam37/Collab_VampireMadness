using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField]
    private UIManager uiManager;

    public List<GameObject> spawnedEnemy = new List<GameObject>();
    public List<Transform> spawningPoints = new List<Transform>();

    //[SerializeField]
    //private Transform ennemyPrefab;

    //[SerializeField]
    //private Transform spawnPoint;

    public GameObject particule;

    [SerializeField]
    private float TimeBetweenWaves = 5f;

    private float countdown = 5f;

    public int waveIndex = 0;

    public int EnemiesAlive = 0;



    // Update is called once per frame
    void Update()
    {

        if (EnemiesAlive > 0)
        {
            return;
        }
        else 
        {
            EnemyController.isMove = false;
            uiManager.ShowProgressBarWave(true);
        }

        if (countdown <= 0f)
        {
           StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves;
            //return;
        }
        countdown -= Time.deltaTime;

        uiManager.UpdateProgressBarWave(countdown/TimeBetweenWaves);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        uiManager.UpdateWaveText();
        uiManager.ShowProgressBarWave(false);

        for ( int i = 0; i < waveIndex; i++)
        {
            //Instantiate(particule, spawnPoint.position, spawnPoint.rotation);
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
            EnemyController.isMove = true;
            
        }

    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, spawnedEnemy.Count);
        int random1 = Random.Range(0, spawningPoints.Count);

        Instantiate(spawnedEnemy[random], spawningPoints[random1].transform.position, spawningPoints[random1].rotation);
        EnemiesAlive++;
    }
}
