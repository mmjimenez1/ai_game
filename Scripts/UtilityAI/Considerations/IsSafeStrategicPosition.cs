using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsSafeStrategicPosition", menuName = "UtilityAI/Considerations/IsSafeStrategicPosition")]
// maximizes distance from player
public class IsSafeStrategicPosition : Consideration
{
    [SerializeField] private AnimationCurve stratPosCurve;

    public override float ScoreConsideration(AIManager aiManager)
    {
        Debug.Log("considering is safe position");

        Player p = aiManager.getPlayer();
        Player enemy = p.getClosestPlayer();
        Vector2 playerPos = p.gameObject.transform.position;
        Vector2 enemyPos = enemy.gameObject.transform.position;

        float distanceBtwn = Vector2.Distance(playerPos,enemyPos);
        //Debug.Log("distanc between players: " + distanceBtwn);
        score = stratPosCurve.Evaluate(Mathf.Clamp01(distanceBtwn));
        //Debug.Log("safe position(teleport) score ="  + score);
        return score;
        
        
    }

}
