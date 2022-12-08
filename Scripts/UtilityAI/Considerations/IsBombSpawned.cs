using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "IsBombSpawned", menuName = "UtilityAI/Considerations/IsBombSpawned")]
public class IsBombSpawned : Consideration
{
    public override float ScoreConsideration(AIManager aiManager)
    {
        return Convert.ToInt32(GameManager.gameManager.bombStation.isActive);
    }
}
