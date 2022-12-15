using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropBomb", menuName = "UtilityAI/Actions/DropBomb")]
public class DropBomb : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        player.bombManager.dropBomb();
    }

    public override void unableAction(AIManager aiManager)
    {
    }
}
