using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HasEnoughEnergyToTeleport", menuName = "UtilityAI/Considerations/HasEnoughEnergyToTeleport")]
public class HasEnoughEnergyToTeleport : Consideration 
{
    [SerializeField] private AnimationCurve responseCurve;
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        int energyCost = p.teleport.epCost;
        int cur_energy = p.energyManager.getEnergyPoints();
        //float enoughEnergy = (float) energyCost / p.energyManager.getEnergyCap();
        float energyDifference = (float)cur_energy - energyCost;
        float energyPercent = (float) energyDifference / p.energyManager.getEnergyCap();
        score = responseCurve.Evaluate(Mathf.Clamp01(energyPercent));
        return score;

    }
}
