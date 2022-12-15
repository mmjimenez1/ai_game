using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAwayOwnBomb", menuName = "UtilityAI/Considerations/PlayerAwayOwnBomb")]
public class PlayerAwayOwnBomb : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        float bombRadius = Bomb.explosionRadius;
        Vector2 bombPosition = player.bombManager.bombComponent.transform.position;
        Vector2 playerPosition = player.gameObject.transform.position;
        bool isAway = Vector2.Distance(playerPosition, bombPosition) > bombRadius;
        return Convert.ToInt32(isAway);
    }
}
