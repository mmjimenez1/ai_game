using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsEnemyShielded", menuName = "UtilityAI/Considerations/IsEnemyShielded")]
public class IsEnemyShielded : Consideration
{
    [SerializeField] private bool invertResponse = false;
    public override float ScoreConsideration(AIManager aiManager)
    {
        Player enemy = aiManager.getPlayer().getClosestPlayer();
        bool isShielded = enemy.shieldManager.isShieldActive();
        if (invertResponse)
            isShielded = !isShielded;
        return Convert.ToInt32(isShielded);
    }
}
