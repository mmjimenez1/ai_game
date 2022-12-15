using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootLaser", menuName = "UtilityAI/Actions/ShootLaser")]
public class ShootLaser : Action
{
    public override void doAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        player.laserManager.setActiveLaser(true);
    }

    public override void unableAction(AIManager aiManager)
    {
        Player player = aiManager.getPlayer();
        player.laserManager.setActiveLaser(false);
    }
}
