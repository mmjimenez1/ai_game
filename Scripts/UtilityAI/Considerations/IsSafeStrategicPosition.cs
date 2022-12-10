using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsSafeStrategicPosition", menuName = "UtilityAI/Considerations/IsSafeStrategicPosition")]

public class IsSafeStrategicPosition : Consideration
{
    [SerializeField] private AnimationCurve stratPosCurve;

    public override float ScoreConsideration(AIManager aiManager)
    {

        throw new System.NotImplementedException();
    }

}
