using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GrabBomb", menuName = "UtilityAI/Actions/GrabBomb")]
public class GrabBomb : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        player.movementManager.isDestinationSet= true;
        player.movementManager.destination = GameManager.gameManager.bombStation.spawnPosition;
    }
}
