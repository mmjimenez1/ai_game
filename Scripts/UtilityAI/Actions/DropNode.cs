using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DropNode", menuName = "UtilityAI/Actions/DropNode")]
public class DropNode : Action
{
    public override void doAction(AIManager aiManager)
    {
        Debug.Log("dropping t node");
        Player p = aiManager.getPlayer();
        p.teleport.dropNode();
        aiManager.onFinishedAction();

    }
}
