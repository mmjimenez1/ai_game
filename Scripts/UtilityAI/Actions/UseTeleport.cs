using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UseTeleport", menuName = "UtilityAI/Actions/UseTeleport")]
public class UseTeleport : Action
{
    public override void doAction(AIManager aIManager)
    {
        Player p = aIManager.getPlayer();
        p.movementManager.isDestinationSet = true;
        p.movementManager.destination = p.teleport.node_location;
    }

    public override void unableAction(AIManager aiManager)
    {
    }
}
