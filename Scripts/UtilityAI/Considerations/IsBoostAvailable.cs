using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsBoostAvailable", menuName = "UtilityAI/Considerations/IsBoostAvailable")]
public class IsBoostAvailable : Consideration
{
    [SerializeField] private bool invertFlag = false;

    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        bool isBoostAvailable = p.boostManager.isAvailable();
        if (invertFlag)
            isBoostAvailable = !isBoostAvailable;

        if (isBoostAvailable)
            score = 1f;
        else
            score = 0f;

        return score;

    }
}
