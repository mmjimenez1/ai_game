using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropBomb", menuName = "UtilityAI/Actions/DropBomb")]
public class DropBomb : Action
{
    public override void doAction(AIManager aiManager)
    {
        Debug.Log("dropping bomb");
        Player player = aiManager.getPlayer();
        player.bombManager.dropBomb();
        aiManager.onFinishedAction();
    }
}
