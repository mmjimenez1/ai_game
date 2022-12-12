using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsShieldActive", menuName = "UtilityAI/Considerations/IsShieldActive")]
public class IsShieldActive : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        bool isActive = p.shieldManager.enabled;
        if (isActive)
        {
            score = 1;
        }
        else
        {
            score = 0;
        }
        return score;


    }

}
