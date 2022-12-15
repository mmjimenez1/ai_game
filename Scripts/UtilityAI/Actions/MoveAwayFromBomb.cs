using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveAwayFromBomb", menuName = "UtilityAI/Actions/MoveAwayFromBomb")]
public class MoveAwayFromBomb : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        float explosionRadius = Bomb.explosionRadius;
        Vector2 playerPosition = player.gameObject.transform.position;

        Vector2 moveTo = Vector2.zero;
        foreach (Bomb bomb in Bomb.bombList)
        {
            // check if the bomb is detonating
            if (!bomb.isDetonated)
                continue;
            // check if the player is in the bomb's radius
            Vector2 bombPosition = bomb.transform.position;
            float distanceToBomb = Vector2.Distance(playerPosition, bombPosition);
            float distanceToRadius = explosionRadius - distanceToBomb;
            if (distanceToRadius < 0)
                continue;
            // set the direction of escape
            Vector2 bombToPlayerVector = playerPosition - bombPosition;
            bombToPlayerVector.Normalize();
            bombToPlayerVector *= distanceToRadius;
            moveTo += bombToPlayerVector;
        }
        moveTo.Normalize();

        player.movementManager.isDestinationSet = true;
        player.movementManager.destination = moveTo;
    }
}
