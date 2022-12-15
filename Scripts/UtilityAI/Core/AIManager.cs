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
        updateActions(0.8f);
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

    private void updateActions(float threshold)
    {
        for (int i = 0; i < possibleActions.Length; i++)
        {
            Action action = possibleActions[i];
            if (brain.scoreAction(action) >= threshold)
            {
                Debug.Log("Doing action: " + action.name + "  " + action.score);
                action.doAction(this);
            }
            else
            {
                action.unableAction(this);
            }
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
