using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveToSafestPosition", menuName = "UtilityAI/Actions/MoveToSafestPosition")]
public class MoveToSafestPosition : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        Player enemy = player.getClosestPlayer();
        Vector2 playerPosition = player.gameObject.transform.position;
        Vector2 enemyPosition = enemy.gameObject.transform.position;
        Vector2 bounds = GameManager.gameManager.bombStation.bounds;

        Vector2[] corners = new Vector2[3];
        corners[0] = new Vector2(bounds.x, bounds.y);
        corners[1] = new Vector2(-bounds.x, bounds.y);
        corners[2] = new Vector2(-bounds.x, -bounds.y);
        corners[3] = new Vector2(bounds.x, -bounds.y);

        Vector2 farthestCorner = corners[0];
        float farthestDistance = float.NegativeInfinity;
        foreach (Vector2 corner in corners)
        {
            float distance = Vector2.Distance(enemyPosition, corner);
            if(distance > farthestDistance)
            {
                farthestCorner = corner;
                farthestDistance = distance;
            }
        }
        Vector2 destinationLocation = (farthestCorner + enemyPosition) * 0.5f;
        Vector2 moveTo = destinationLocation - playerPosition;
        moveTo.Normalize();

        player.movementManager.isDestinationSet = true;
        player.movementManager.destination = moveTo;
    }
}
