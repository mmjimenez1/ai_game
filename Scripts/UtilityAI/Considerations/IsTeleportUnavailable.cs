using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsTeleportUnavailable", menuName = "UtilityAI/Considerations/IsTeleportUnavailable")]

public class IsTeleportUnavailable : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        bool isInCoolDown = !(p.teleport.cur_tel_cool_down > 0);
        Debug.Log("is in cool down:" + isInCoolDown);
        if (isInCoolDown)
            score = 0;
        else
            score = 1;

        return score;

    }
}
