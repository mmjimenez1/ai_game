using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsBombDropped", menuName = "UtilityAI/Considerations/IsBombDropped")]
public class IsBombDropped : Consideration
{
    [SerializeField] private bool invertResponse = false;

    public override float ScoreConsideration(AIManager aiManager)
    {
        bool IsBombDropped = aiManager.getPlayer().bombManager.isActive;
        if (invertResponse)
            IsBombDropped = !IsBombDropped;
        return Convert.ToInt32(IsBombDropped);
    }
}
