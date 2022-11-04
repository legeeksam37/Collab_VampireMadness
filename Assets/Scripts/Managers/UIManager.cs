using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    [Header("Main UI")]
    public GameObject WaveText;
    public Slider WaveDelayProgress;
    public Slider HealthBar;
    private WaveSpawner waveSpawner;
    public PlayerStats player;
    public GameObject PointsText;

    public PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject WaveTextGO = PhotonNetwork.Instantiate(WaveText.name, new Vector2(0,0), Quaternion.identity);
        WaveText = GameObject.FindGameObjectWithTag("WaveCount");
        WaveDelayProgress = GameObject.FindGameObjectWithTag("WaveDelayProgress").GetComponent<Slider>();
        HealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        view = GetComponent<PhotonView>();
        WaveSpawner[] spawners = PhotonView.FindObjectsOfType<WaveSpawner>();
        foreach (WaveSpawner spawner in spawners)
        {
            if (spawner.tag == "WaveManager"){
                waveSpawner = spawner;
            }
        }
        player = GameObject.FindObjectOfType<PlayerStats>();
        PointsText = GameObject.FindGameObjectWithTag("PointsText");
        updatePoints();
        // if (PhotonNetwork.IsMasterClient == true){
        //     WaveDelayProgress.gameObject.SetActive(true);
        // } else {
        //     WaveDelayProgress.gameObject.SetActive(false);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWaveText()
    {
        //Debug.Log(WaveText.GetComponent<TextMeshProUGUI>().text);
        //string s = "";
        //view.RPC("updateText", RpcTarget.All, s);
        WaveText.GetComponent<TextMeshProUGUI>().text = waveSpawner.waveIndex.ToString();;
    }

    [PunRPC]
    public void updateText(string s){
        Debug.Log("Hello");
        if (PhotonNetwork.IsMasterClient == true){
            s = waveSpawner.waveIndex.ToString();
        }
    }

    public void UpdateProgressBarWave(float progression)
    {
        WaveDelayProgress.value = progression;
        Debug.Log(WaveDelayProgress.value);
    }

    public void ShowProgressBarWave(bool state)
    {
        WaveDelayProgress.gameObject.SetActive(state);
    }

    public void UpdateHealthBar(float progression)
    {
        HealthBar.value = progression / 100;
    }

    public void updatePoints()
    {
        PointsText.GetComponent<TextMeshProUGUI>().text = player.Points.ToString();
    }
}
