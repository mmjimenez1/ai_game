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
        float radius = p.bombManager.bombComponent.explosionRadius;
        Vector2 playerPos = p.gameObject.transform.position;
        List<Vector2> bombLocations = GameManager.gameManager.getBombLocation();
        float shortestDist = 10000f;
        int shortestDistPos = 0;

        // find the closest bomb to the player
        for (int i = 0; i < bombLocations.Count; i++)
        {
            if (Vector2.Distance(playerPos, bombLocations[i]) > radius)
            {
                if (Vector2.Distance(playerPos, bombLocations[i]) < shortestDist)
                {
                    shortestDist = Vector2.Distance(playerPos, bombLocations[i]);
                    shortestDistPos = i;
                }
                Debug.Log("Player in bomb radius");
            }
        }

        // calculate the time it would take to escape the radius
        // thinking calculate it based on velocity

        float enoughDistance = 1 - (shortestDist / 3);
        score = distanceAwayCurve.Evaluate(Mathf.Clamp01(enoughDistance));
        return score;
    }
}
