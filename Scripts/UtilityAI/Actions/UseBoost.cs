using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UseBoost", menuName = "UtilityAI/Actions/UseBoost")]
public class UseBoost : Action
{
    public override void doAction(AIManager aiManager)
    {
        Debug.Log("using boost");
        Player player = aiManager.getPlayer();
        player.boostManager.Boost();
        aiManager.onFinishedAction();
    }
}
