using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Main UI")]
    [SerializeField]
    private GameObject WaveText;
    [SerializeField]
    private Slider WaveDelayProgress;

    [SerializeField]
    private WaveSpawner WaveSpawner;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWaveText()
    {
        WaveText.GetComponent<TextMeshProUGUI>().text = WaveSpawner.waveIndex.ToString();
    }

    public void UpdateProgressBarWave(float progression)
    {
        WaveDelayProgress.value = progression;
    }

    public void ShowProgressBarWave(bool state)
    {
        WaveDelayProgress.gameObject.SetActive(state);

    }
}
