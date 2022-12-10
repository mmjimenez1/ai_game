using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "isInPickUpRange", menuName = "UtilityAI/Considerations/isInPickUpRange")]
public class isInPickUpRange : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        return 0;

    }
}

