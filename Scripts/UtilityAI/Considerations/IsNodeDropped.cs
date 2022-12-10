using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsNodeDropped", menuName = "UtilityAI/Considerations/IsNodeDropped")]
public class IsNodeDropped : Consideration
{
    [SerializeField] private bool invertFlag = false;
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        bool isnodeDropped = p.teleport.is_dropped;
        if (invertFlag)
        {
            isnodeDropped = !isnodeDropped;

        }

        if(isnodeDropped == true)
        {
            score = 1f;
        }
        else
        {
            score = 0f;
        }

        return score;
    }
}
