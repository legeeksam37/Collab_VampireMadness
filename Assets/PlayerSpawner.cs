using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class PlayerSpawner : MonoBehaviour
{


    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    private static PlayerSpawner instance;
    public static PlayerSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerSpawner>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX,maxX), Random.Range(minY,maxY), Random.Range(minZ,maxZ));
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }

    public void Respawn(GameObject Player)
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        GameObject player = PhotonNetwork.Instantiate(Player.name, randomPosition, Quaternion.identity);
    }
}
