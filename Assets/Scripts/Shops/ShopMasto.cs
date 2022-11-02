using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMasto : InteractionBase
{
    [SerializeField]
    private float buyCost;

    [SerializeField]
    private float boostValue;

    [SerializeField]
    private float priceEvolution;


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
        }
        else
        {
            Debug.Log("Not enough points");
        }
    }
}
