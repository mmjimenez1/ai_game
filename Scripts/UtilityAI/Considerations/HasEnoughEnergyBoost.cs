using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HasEnoughEnergyBoost", menuName = "UtilityAI/Considerations/HasEnoughEnergyBoost")]
public class HasEnoughEnergyBoost : Consideration
{
    [SerializeField] private bool invertResponse = false;
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        int epCost = player.boostManager.epCost;
        int playerEP = player.energyManager.getEnergyPoints();
        bool hasEnough = epCost <= playerEP;
        if (invertResponse)
            hasEnough = !hasEnough;
        return Convert.ToInt32(hasEnough);
    }
}
