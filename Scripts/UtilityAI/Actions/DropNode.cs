using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropNode : Action
{
    public override void doAction(Player myPlayer){
        myPlayer.teleport.dropNode();
    }
}
