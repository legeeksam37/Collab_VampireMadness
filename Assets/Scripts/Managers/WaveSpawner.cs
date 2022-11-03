using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

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


    void Start()
    {
       if(PhotonNetwork.IsMasterClient == true)
       {
           gameObject.SetActive(true);
       }
       else
       {
           gameObject.SetActive(false);
       }
        uiManager = GameObject.FindObjectOfType<UIManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0)
        {
//            Debug.Log(EnemiesAlive);
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

        GameObject _newEnemy = Instantiate(spawnedEnemy[random], spawningPoints[random1].transform.position, spawningPoints[random1].rotation);
        _newEnemy.gameObject.transform.SetParent(GameObject.Find("GameObjects").gameObject.transform);

        EnemiesAlive++;
    }
}
