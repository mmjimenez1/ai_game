using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UseTeleport", menuName = "UtilityAI/Actions/UseTeleport")]
public class UseTeleport : Action
{
    public override void doAction(AIManager aIManager)
    {
        Debug.Log("using teleport");
        Player p = aIManager.getPlayer();
        p.movementManager.isDestinationSet = true;
        p.movementManager.destination = p.teleport.node_location;
        aIManager.onFinishedAction();
    }
}
