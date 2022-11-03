using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private UIManager hudManager;

    [Header("Player stats")]

    public float PV = 100f;
    
    public float Points = 0f;

    public float SpellsPower = 1f;


    void Update()
    {
        Debug.Log(PV);
        Death();
    }
    public void UsePoints(float amount)
    {
        Points -= amount;
    }

    public void TakeDamage(float amount)
    {
        PV -= amount;
        hudManager.UpdateHealthBar(PV);
    }

    public void Death()
    {
        if(PV <= 0f)
        {
            SceneManager.LoadScene("MainLevel");
        }
    }

    public void AddPoints(int amount)
    {
        Points += amount;
        Debug.Log(Points.ToString());
    }
}
