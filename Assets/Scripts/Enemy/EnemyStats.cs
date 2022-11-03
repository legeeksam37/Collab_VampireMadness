using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]

    public float PV = 100f;

    public float damage = 0f;

    [SerializeField]
    int pointsOnDeath;

    private WaveSpawner waveSpawner;

    public PhotonView view;

    void Start()
    {
        waveSpawner = GameObject.FindWithTag("WaveManager").GetComponent<WaveSpawner>();
        view = GetComponent<PhotonView>();
    }


    public void TakeDamage(float damage, PlayerStats playerDealDamage)
    {
        PV -= damage;

        if (PV <= 0)
        {
            view.RPC("Destroy", RpcTarget.All, playerDealDamage);
        }
    }

    [PunRPC]
    public void networkDestroy(PlayerStats playerDealDamage){
        if (waveSpawner != null){
            if (waveSpawner.EnemiesAlive != 0)
            {
                waveSpawner.EnemiesAlive -= 1;
            }

            playerDealDamage.AddPoints(pointsOnDeath);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
