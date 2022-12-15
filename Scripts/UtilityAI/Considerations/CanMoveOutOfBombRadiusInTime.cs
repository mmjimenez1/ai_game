using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CanMoveOutOfBombRadiusInTime", menuName = "UtilityAI/Considerations/CanMoveOutOfBombRadiusInTime")]
public class CanMoveOutOfBombRadiusInTime : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        float playerSpeed = player.movementManager.baseSpeed;
        Vector2 playerPos = player.gameObject.transform.position;
        Player enemy = player.getClosestPlayer();

        float explosionRadius = Bomb.explosionRadius;
        // check for all detonating bombs
        foreach (Bomb bomb in Bomb.bombList){
            if (!bomb.isDetonated) continue;
            Vector2 bombPosition = bomb.transform.position;
            float distance = Vector2.Distance(bombPosition, playerPos);
            float distanceToRadius = explosionRadius - distance;
            if (distanceToRadius < 0f)
                continue;
            float secondsToFlee = distanceToRadius / playerSpeed;
            float secondsTillDamage = bomb.timeTillDamage();
            // if there is not enough time to flee, return false
            if(secondsToFlee > secondsTillDamage)
                return Convert.ToInt32(false);
        }
        return Convert.ToInt32(true);
    }
}
