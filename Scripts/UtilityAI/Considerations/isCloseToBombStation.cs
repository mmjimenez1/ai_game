using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "isCloseToBombStation", menuName = "UtilityAI/Considerations/isCloseToBombStation")]
public class isCloseToBombStation : Consideration
{
    [SerializeField] private AnimationCurve responseCurve;

    public override float ScoreConsideration(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        Vector2 playerPosition = player.gameObject.transform.position;
        Vector2 stationPosition = GameManager.gameManager.bombStation.spawnPosition;
        float distance = Vector2.Distance(stationPosition, playerPosition);
        float mapWidth = 2f * GameManager.gameManager.bombStation.bounds.x;
        float ratio = distance / mapWidth;
        score = responseCurve.Evaluate(Mathf.Clamp01(ratio));
        return score;
    }
}
