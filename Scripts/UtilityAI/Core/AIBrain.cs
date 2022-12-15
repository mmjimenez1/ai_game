using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIBrain : MonoBehaviour
{
    public Action bestAction { get; set; }
    public bool finishedDeciding { get; set; }
    private AIManager aiManager;

    void Start()
    {
        aiManager = GetComponent<AIManager>();
    }

    void Update()
    {
        if(bestAction = null)
        {
            decideBestAction(aiManager.possibleActions);
        }
    }

    public void decideBestAction(Action[] actionsAvailable)
    {
        float score = 0f;
        int bestActionIndex = 0;
        for (int i = 0; i < actionsAvailable.Length; i++)
        {
            if (scoreAction(actionsAvailable[i]) > score)
            {
                bestActionIndex = i;
                score = actionsAvailable[i].score;
            }
        }

        bestAction = actionsAvailable[bestActionIndex];
        finishedDeciding = true;
    }

    public Action decideBestMovement(Action[] movementActions)
    {
        float score = 0f;
        int bestActionIndex = 0;
        Debug.Log("Analyzing movements: ");
        for (int i = 0; i < movementActions.Length; i++)
        {
            if (scoreAction(movementActions[i]) > score)
            {
                bestActionIndex = i;
                score = movementActions[i].score;
            }
            Debug.Log(movementActions[i] + " : " + movementActions[i].score);
        }
        return movementActions[bestActionIndex];
    }

    public float scoreAction(Action curAction)
    {
        float score = 1f;
        for(int i = 0; i < curAction.considerations.Length; i++)
        {
            float curScore = curAction.considerations[i].ScoreConsideration(aiManager);
            score *= curScore;

            if(score == 0f)
            {
                curAction.score = 0f;
                return curAction.score;
            }
        }
        
        float ogScore = score;
        float modFactor = 1f - (1f / curAction.considerations.Length);
        float makeupValue = (1f - ogScore) * modFactor;
        curAction.score = ogScore + (makeupValue * ogScore);

        return curAction.score;
    }




}
