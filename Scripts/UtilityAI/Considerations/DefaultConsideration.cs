using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultConsideration", menuName = "UtilityAI/Considerations/DefaultConsideration")]
public class DefaultConsideration : Consideration
{

    public override float ScoreConsideration(AIManager aiManager)
    {
        return 0.5f;
    }
}
