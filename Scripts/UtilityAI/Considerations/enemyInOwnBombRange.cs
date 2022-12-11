using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemyInOwnBombRange", menuName = "UtilityAI/Considerations/enemyInOwnBombRange")]
public class EnemyInOwnBombRange : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        float boomRadius = player.bombManager.bombComponent.explosionRadius;
        Vector2 bombPosition = player.bombManager.bombComponent.transform.position;
        Vector2 enemyPosition = player.getClosestPlayer().gameObject.transform.position;
        bool inRange = Vector2.Distance(enemyPosition, bombPosition) < boomRadius;
        return Convert.ToInt32(inRange);
    }
}
