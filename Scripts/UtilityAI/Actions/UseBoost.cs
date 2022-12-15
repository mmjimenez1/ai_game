using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UseBoost", menuName = "UtilityAI/Actions/UseBoost")]
public class UseBoost : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        player.boostManager.Boost();
    }

    public override void unableAction(AIManager aiManager)
    {
    }
}
