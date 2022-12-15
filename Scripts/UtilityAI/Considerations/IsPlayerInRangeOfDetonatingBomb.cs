using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsPlayerInRangeOfDetonatingBomb", menuName = "UtilityAI/Considerations/InDetonatingBombRange")]
// player in range of dropped bomb, possible detonation
public class IsPlayerInRangeOfDetonatingBomb : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        Debug.Log("considering whether player in range of detonating bomb");
        Player p = aiManager.getPlayer();
        float radius = Bomb.explosionRadius;
        Vector2 playerPos = p.gameObject.transform.position;
        //List<Vector2> bombLocations = GameManager.gameManager.getBombLocation();
        //for (int i =0; i< bombLocations.Count; i++)
        //{
        //    if (Vector2.Distance(playerPos, bombLocations[i]) < radius)
        //    {
        //        Debug.Log("Player in bomb radius, teleport!");
        //        return 1;
        //    }
        //}
        foreach(Bomb bomb in Bomb.bombList)
        {
            Vector2 bombPos = bomb.transform.position;
            if (Vector2.Distance(playerPos, bombPos) < radius)
            {
                Debug.Log("Player in bomb radius, teleport!");
                return 1;
            }
        }
        Debug.Log("player not in bomb radius");
        return 0;

    }
}
