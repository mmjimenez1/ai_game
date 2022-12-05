using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Spawnable Item/EnergyStation", order = 1)]
public class EnergyStation : SpawnableItem
{
    // flash icon from https://icons8.com
    protected override void setUpItemScale()
    {
        //item.transform.localScale = new Vector2(0.05510619f, 0.05510619f);
    }

    public override void pickUp(Player player)
    {
        Debug.Log(itemName + " -> " + player.username + " + " + pickUpAmount + " EP");
        player.energyManager.plusEP(pickUpAmount);
    }
}
