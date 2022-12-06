using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsBombStrategicPos", menuName = "UtilityAI/Considerations/IsBombStrategicPos")]
public class IsBombStrategicPos : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        //bool IsBombStrategicPos = aiManager.getPlayer().bombManager.getBombAmt() > 0;
        return Convert.ToInt32(IsBombStrategicPos);
    }
}
