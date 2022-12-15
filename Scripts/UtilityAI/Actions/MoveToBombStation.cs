using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveToBombStation", menuName = "UtilityAI/Actions/MoveToBombStation")]
public class MoveToBombStation : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        player.movementManager.isDestinationSet= true;
        player.movementManager.destination = GameManager.gameManager.bombStation.spawnPosition;
    }
}
