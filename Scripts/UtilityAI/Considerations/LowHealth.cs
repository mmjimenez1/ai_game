using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LowHealth", menuName = "UtilityAI/Considerations/LowHealth")]
public class LowHealth : Consideration
{
    [SerializeField] private AnimationCurve healthCurve;
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        int curHealth = p.healthManager.getHealthPoints();
        int healthMax = p.healthManager.getHealthCap();
        float healthPercent = (float) curHealth / healthMax;
        //Debug.Log("health %:" + healthPercent);

        score = healthCurve.Evaluate(Mathf.Clamp01(healthPercent));
        //Debug.Log("health score:" + score);
        return score;
    }
}
