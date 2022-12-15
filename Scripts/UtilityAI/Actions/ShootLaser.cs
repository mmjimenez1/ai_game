using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootLaser", menuName = "UtilityAI/Actions/ShootLaser")]
public class ShootLaser : Action
{
    public override void doAction(AIManager aiManager)
    {
        Debug.Log("shooting laser");
        Player player = aiManager.getPlayer();
        player.laserManager.setActiveLaser(true);
        aiManager.onFinishedAction();
    }
}
