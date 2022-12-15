using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : ManagerClass
{
    public AIBrain brain { get; set; }
    public Action[] possibleActions;
    public Action[] movementActions;

    private void Start()
    {

    }

    private void Update()
    {
        updateMovement();
        //if (brain.finishedDeciding)
        //{
        //    brain.finishedDeciding = false;
        //    brain.bestAction.doAction(this);
        //}
    }

    private void updateMovement()
    {
        Action movement = brain.decideBestMovement(movementActions);
        movement.doAction(this);
    }

    public void onFinishedAction(){
        brain.decideBestAction(possibleActions);
    }

    public Player getPlayer()
    {
        return myPlayer;
    }
}
