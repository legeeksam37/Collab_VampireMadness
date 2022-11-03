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

    private void Start()
    {
        hudManager = GameObject.FindObjectOfType<UIManager>();
    }

    void Update()
    {
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
            PlayerSpawner.Instance.Respawn(this.gameObject);
        }
    }

    public void AddPoints(int amount)
    {
        Points += amount;
        Debug.Log(Points.ToString());
    }
}
