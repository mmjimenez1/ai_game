using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : ManagerClass
{
    public AIBrain brain { get; set; }
    public Action[] possibleActions;
    public Action[] movementActions;

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
        Debug.Log("Best movement: " + movement.name + "  " + movement.score);
    }

    private void updateActions()
    {
        List<Action> actions = brain.getAvailableActions(possibleActions, 0.8f);
        foreach (Action action in actions) {
            action.doAction(this);
        }
    }

    public void onFinishedAction(){
        brain.decideBestAction(possibleActions);
    }

    public Player getPlayer()
    {
        return myPlayer;
    }
}
