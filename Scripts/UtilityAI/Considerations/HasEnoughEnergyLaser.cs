using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HasEnoughEnergyLaser", menuName = "UtilityAI/Considerations/HasEnoughEnergyLaser")]
public class HasEnoughEnergyLaser : Consideration
{
    [SerializeField] private AnimationCurve responseCurve;
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        int eps = player.laserManager.epPerSecond;
        int dps = player.laserManager.dmgPerSecond;
        int playerEP = player.energyManager.getEnergyPoints();

        Player enemy = player.getClosestPlayer();
        int enemyHealth = enemy.healthManager.getHealthPoints();
        float secondsNeeded = (float)enemyHealth / (float)dps;
        float energyNeeded = (float)eps * secondsNeeded;
        float energyRatio = (float)playerEP / energyNeeded;
        score = responseCurve.Evaluate(Mathf.Clamp01(energyRatio));
        return score;
    }
}
