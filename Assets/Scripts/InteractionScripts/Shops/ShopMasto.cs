using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShopMasto : InteractionBase
{
    [SerializeField]
    private float buyCost;

    [SerializeField]
    private float boostValue;

    [SerializeField]
    private float priceEvolution;

    [SerializeField]
    private Text testMasto;

    public void Start()
    {
        testMasto.text = "Points : " + buyCost.ToString();
    }

    public override void Action(GameObject player)
    { 
        base.Action(player);

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
       

        if(playerStats.Points >= buyCost)
        {
            playerStats.SpellsPower *= boostValue;
            playerStats.UsePoints(buyCost);
            Debug.Log("Masto shop buy");

            buyCost *= priceEvolution;
            buyCost = Mathf.Round(buyCost);
            testMasto.text = "Points : " + buyCost.ToString();
        }
        else
        {
            Debug.Log("Not enough points");
        }
    }
}
