using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombsQTY", menuName = "UtilityAI/Considerations/BombsQTY")]
public class BombsQTY : Consideration
{
    [SerializeField] private AnimationCurve responseCurve;

    public override float ScoreConsideration(AIManager aiManager)
    {
        int bombAmount = aiManager.getPlayer().bombManager.getBombAmt();
        float enoughBombs = (float) bombAmount / 5f; ;
        score = responseCurve.Evaluate(Mathf.Clamp01(enoughBombs));
        return score;
    }
}
