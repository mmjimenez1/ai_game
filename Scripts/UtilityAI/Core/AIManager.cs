using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : ManagerClass
{
    public AIBrain brain { get; set; }
    public Action[] possibleActions;

    private void Start()
    {
        brain = GetComponent<AIBrain>();

    }

    private void Update()
    {
        if (brain.finishedDeciding)
        {
            brain.finishedDeciding = false;
            brain.bestAction.doAction(this);
        }
    }

    public void onFinishedAction(){
        brain.decideBestAction(possibleActions);
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
