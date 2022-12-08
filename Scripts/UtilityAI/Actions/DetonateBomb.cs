using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DetonateBomb", menuName = "UtilityAI/Actions/DetonateBomb")]
public class DetonateBomb : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        player.bombManager.detonateBomb();
    }
}
