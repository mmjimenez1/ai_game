using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIManager: ManagerClass
{
    public AIBrain brain { get; set; }
    public Action[] possibleActions;

    private void Start()
    {
        
    }

    private void Update()
    {
        brain = GetComponent<AIBrain>();
    }

    public Player getPlayer()
    {
        return myPlayer;
    }

    public void GrabBomb()
    {
        //StartCoroutine(GrabBomb)
    }
}
