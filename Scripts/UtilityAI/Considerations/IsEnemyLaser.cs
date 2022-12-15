using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsEnemyLaser", menuName = "UtilityAI/Considerations/IsEnemyLaser")]

// should this be detected enemy laser shoooting?
public class IsEnemyLaser : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        score = 0f;
        Player p = aiManager.getPlayer();
        //List<Player> enemies = Player.getEnemies(p);
        Player enemy = p.getClosestPlayer();
        //foreach (Player player in enemies)
        //{
            if (enemy.laserManager.isActive)
            {
                Debug.Log("enemy player laser active");
                score = 1f;
            }
        //}

        return score;
    }

}
