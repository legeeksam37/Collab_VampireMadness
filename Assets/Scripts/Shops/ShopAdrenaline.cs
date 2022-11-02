using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAdrenaline : InteractionBase
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

        ThirdPersonController playerController = player.GetComponent<ThirdPersonController>();
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
       

        if(playerStats.Points >= buyCost)
        {
            playerController.SprintSpeed *= boostValue;
            playerStats.UsePoints(buyCost);
            Debug.Log("Adrenaline shop buy");

            buyCost *= priceEvolution;
            buyCost = Mathf.Round(buyCost);
        }
        else
        {
            Debug.Log("Not enough points");
        }
    }
}
