using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsEnemyLowHealth", menuName = "UtilityAI/Considerations/IsEnemyLowHealth")]
public class IsEnemyLowHealth : Consideration
{
    [SerializeField] private AnimationCurve responseCurve;
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player enemy = aiManager.getPlayer().getClosestPlayer();
        int enemyHealth = enemy.healthManager.getHealthPoints();
        int enemyHealthCap = enemy.healthManager.getHealthCap();
        float healthRatio = (float) enemyHealth / (float)enemyHealthCap;
        score = responseCurve.Evaluate(Mathf.Clamp01(healthRatio));
        return score;
    }
}
