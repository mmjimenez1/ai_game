using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerClass : MonoBehaviour
{
    protected Player myPlayer;

    public void setPlayer(Player p)
    {
        this.myPlayer = p;
    }
}
