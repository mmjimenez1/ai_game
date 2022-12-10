using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DropNode", menuName = "UtilityAI/Actions/DropNode")]
public class DropNode : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        p.teleport.dropNode();

    }
}
