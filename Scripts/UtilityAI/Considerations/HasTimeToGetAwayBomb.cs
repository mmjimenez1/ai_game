using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HasTimeToGetAwayBomb", menuName = "UtilityAI/Considerations/HasTimeToGetAwayBomb")]
public class HasTimeToGetAwayBomb : Consideration
{
    [SerializeField] private float radius = 3;
    [SerializeField] AnimationCurve distanceAwayCurve;
    // assuming has time to get away = bomb not detonated but placed
    // has time to get away from nearest bomb
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player p = aiManager.getPlayer();
        Vector2 playerPos = p.gameObject.transform.position;
        List<Vector2> bombLocations = GameManager.gameManager.getBombLocation();
        float shortestDist = 10000f;
        for (int i = 0; i < bombLocations.Count; i++)
        {
            if (Vector2.Distance(playerPos, bombLocations[i]) > radius)
            {
                if (Vector2.Distance(playerPos, bombLocations[i]) < shortestDist)
                    shortestDist = Vector2.Distance(playerPos, bombLocations[i]);
                Debug.Log("Player in bomb radius");
            }
        }

        float enoughDistance = 1 - (shortestDist / 3);
        score = distanceAwayCurve.Evaluate(Mathf.Clamp01(enoughDistance));
        return score;
    }
}
