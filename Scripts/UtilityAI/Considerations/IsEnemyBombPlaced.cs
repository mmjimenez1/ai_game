using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsEnemyBombPlaced", menuName = "UtilityAI/Considerations/IsEnemyBombPlaced")]

public class IsEnemyBombPlaced : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        score = 0f;
        Player p = aiManager.getPlayer();
        List<Player> enemies = Player.getEnemies(p);
        foreach(Player player in enemies)
        {
            if (player.bombManager.isActive)
            {
                score = 1f;
            }
        }

        return score;
    }
}
