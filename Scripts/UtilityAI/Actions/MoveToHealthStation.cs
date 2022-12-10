using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveToHealthStatation", menuName = "UtilityAI/Actions/MoveToHealthStatation")]
public class MoveToHealthStation : Action
{
    public override void doAction(AIManager aIManager)
    {
        Player p = aIManager.getPlayer();
        p.movementManager.isDestinationSet = true;
        p.movementManager.destination = GameManager.gameManager.healthStation.spawnPosition;
    }
}
