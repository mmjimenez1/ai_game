using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsBombStrategicPos", menuName = "UtilityAI/Considerations/IsBombStrategicPos")]
public class IsBombStrategicPos : Consideration
{
    [SerializeField] private AnimationCurve responseCurve;

    public override float ScoreConsideration(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        Player enemy = player.getClosestPlayer();
        Vector2 playerPosition = player.gameObject.transform.position;
        Vector2 enemyPosition = enemy.gameObject.transform.position;
        float shortestDistance = Vector2.SqrMagnitude(enemyPosition - playerPosition);
        Vector2 bounds = GameManager.gameManager.bombStation.bounds;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                float x = i * bounds.x / 2f;
                float y = j * bounds.y / 2f;
                Vector2 strategicPosition = new Vector2(x, y);
                float distance = Vector2.SqrMagnitude(strategicPosition - playerPosition);
                if(distance < shortestDistance)
                    distance = shortestDistance;
            }
        }
        shortestDistance = Mathf.Sqrt(shortestDistance);
        // only care if the distance < 1f
        score = responseCurve.Evaluate(Mathf.Clamp01(shortestDistance));
        return score;
    }
}
