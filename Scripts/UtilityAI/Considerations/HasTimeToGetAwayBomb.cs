using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HasTimeToGetAwayBomb", menuName = "UtilityAI/Considerations/HasTimeToGetAwayBomb")]
public class HasTimeToGetAwayBomb : Consideration

{
    [SerializeField] AnimationCurve distanceAwayCurve;
    // assuming has time to get away = bomb not detonated but placed
    // has time to get away from nearest bomb
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        float radius = Bomb.explosionRadius;
        Vector2 playerPos = p.gameObject.transform.position;
        float shortestDist = 10000f;
        float timeTillDamage = 0;

        foreach(Bomb bomb in Bomb.bombList)
        {
            if (Vector2.Distance(playerPos, bomb.transform.position) < radius && (!bomb.isDetonated) )
            {
                Debug.Log("Player in bomb radius");

                if (Vector2.Distance(playerPos, bomb.transform.position) < shortestDist)
                {
                    shortestDist = Vector2.Distance(playerPos, bomb.transform.position);
                    timeTillDamage = bomb.timeTillDamage();
                }
            }

        }

        float timeToExitRadius = (shortestDist )/ p.movementManager.baseSpeed;
        float timeDifference = timeTillDamage - timeToExitRadius;
        score = distanceAwayCurve.Evaluate(Mathf.Clamp01(timeDifference));
        return score;
    }
}
