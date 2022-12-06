using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HasBomb", menuName = "UtilityAI/Considerations/HasBomb")]
public class HasBomb : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        bool hasBomb = aiManager.getPlayer().bombManager.getBombAmt() > 0;
        return Convert.ToInt32(hasBomb);
    }
}
