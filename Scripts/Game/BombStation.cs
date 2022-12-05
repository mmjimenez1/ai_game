using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Spawnable Item/BombStation", order = 1)]
public class BombStation : SpawnableItem
{
    protected override void setUpItemScale()
    {
        item.transform.localScale = new Vector2(0.2f, 0.2f);
    }

    public override void pickUp(Player player)
    {
        Debug.Log(itemName + " -> " + player.username + " + " + pickUpAmount + " bomb");
        player.bombManager.pickUpBomb(pickUpAmount);
    }
}

