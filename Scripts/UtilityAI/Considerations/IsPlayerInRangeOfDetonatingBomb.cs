using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsPlayerInRangeOfDetonatingBomb", menuName = "UtilityAI/Considerations/InDetonatingBombRange")]

public class IsPlayerInRangeOfDetonatingBomb : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    { 
        Player p = aiManager.getPlayer();
        float radius = p.bombManager.bombComponent.explosionRadius;
        Vector2 playerPos = p.gameObject.transform.position;
        List<Vector2> bombLocations = GameManager.gameManager.getBombLocation();
        for (int i =0; i< bombLocations.Count; i++)
        {
            if (Vector2.Distance(playerPos, bombLocations[i]) > radius)
            {
                Debug.Log("Player in bomb radius, teleport!");
                return 1;
            }
        }

        Debug.Log("player not in bomb radius");
        return 0;

    }
}
