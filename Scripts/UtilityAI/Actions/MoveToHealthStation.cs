using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHealthStation : Action
{
    private Vector2 station_position;

    public override void doAction(Player myPlayer)
    {
        findStation();
        //myPlayer.movementManager.moveManager();
    }

    private void findStation()
    {
        //station_position = StationBehavior.station_pos;
    }


}
