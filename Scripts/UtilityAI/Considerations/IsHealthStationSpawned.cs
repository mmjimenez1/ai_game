using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsHealthStationSpawned", menuName = "UtilityAI/Considerations/IsHealthStationSpawned")]
public class IsHealthStationSpawned : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
       bool isHSpawned = GameManager.gameManager.healthStation.isActive;
     
        if (isHSpawned)
        {
            score = 1f;
        }
        else
        {
            score = 0f;
        }

        return score;
    }
}
