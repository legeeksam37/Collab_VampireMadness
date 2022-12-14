using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX,maxX), Random.Range(minY,maxY), Random.Range(minZ,maxZ));
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

        // if (!player.GetPhotonView().IsMine)
        //     return;
        // player.transform.Find("Camera").gameObject.GetComponent<CameraControler>().enabled = true;
        // player.transform.Find("Camera").gameObject.GetComponent<CameraControler>().SetTarget(player.transform);
        // player.transform.Find("Camera").gameObject.SetActive(true);
    }

}
