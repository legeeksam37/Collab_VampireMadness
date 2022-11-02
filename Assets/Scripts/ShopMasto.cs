using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMasto : InteractionBase
{
    [SerializeField]
    private int buyCost;

    public override void Action(GameObject player)
    { 
        base.Action(player);

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
       

        if(playerStats.Points >= buyCost)
        {
            playerStats.SpellsPower *= 1.05f;
            playerStats.UsePoints(buyCost);
            Debug.Log("Masto shop buy");
        }
        else
        {
            Debug.Log("Not enough points");
        }
    }
}
