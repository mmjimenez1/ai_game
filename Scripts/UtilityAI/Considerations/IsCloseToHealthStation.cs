using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsCloseToHealthStation", menuName = "UtilityAI/Considerations/IsCloseToHealthStation")]
public class IsCloseToHealthStation : Consideration
{
    [SerializeField] AnimationCurve disHealthStation;

    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        Vector2 stationPos = GameManager.gameManager.healthStation.spawnPosition;
        float distanceBtwn = Vector2.Distance(stationPos, p.gameObject.transform.position);
        score = disHealthStation.Evaluate(Mathf.Clamp01(distanceBtwn));

        return score;

    }
}
