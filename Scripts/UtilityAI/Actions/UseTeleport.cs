using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTeleport : Action
{
    public override void doAction(Player myPlayer)
    {
        myPlayer.teleport.teleport_object(myPlayer.teleport.node_location);
    }
}
