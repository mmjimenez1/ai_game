using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RotateShield", menuName = "UtilityAI/Actions/RotateShield")]
public class RotateShield : Action
{
    public override void doAction(AIManager aiManager)
    {
        Debug.Log("rotating shield");
        Player p = aiManager.getPlayer();
        Player enemy = p.getClosestPlayer();
        Vector2 targetPos = Vector2.zero;

        // Turn to direction of nearest bomb or laser if laser is active
        // and felt damage?

        if (enemy.bombManager.isActive && (!enemy.laserManager.isActive))
        {
            targetPos = enemy.bombManager.bombLocation;

        }

        if (enemy.laserManager.isActive)
        {
            targetPos = enemy.gameObject.transform.position;
        }

        // idk what this does...
        targetPos.Normalize();
        float newAngle = -Vector2.SignedAngle(targetPos, Vector2.up);
        p.shieldManager.setTargetRotation(Quaternion.Euler(new Vector3(0, 0, newAngle)));
        p.shieldManager.updateRotation();
    }

    public override void unableAction(AIManager aiManager)
    {
    }
}
