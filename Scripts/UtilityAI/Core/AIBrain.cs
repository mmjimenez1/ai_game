using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIBrain : MonoBehaviour
{
    public Action bestAction { get; set; }
    private AIManager aiManager;

    void Start()
    {
        aiManager = GetComponent<AIManager>();
    }

    void Update()
    {
    }

    public void decideBestAction(Action[] actionsAvailable)
    {
        float score = 0f;
        int bestActionIndex = 0;
        for(int i = 0; i < actionsAvailable.Length; i++)
        {
            if (scoreAction(actionsAvailable[i])> score)
            {
                bestActionIndex = i;
                score = actionsAvailable[i].score;
            }
        }

        bestAction = actionsAvailable[bestActionIndex];


    }

    public float scoreAction(Action curAction)
    {
        float score = 1f;
        for(int i= 0; i< curAction.considerations.Length; i++)
        {
            float curScore = curAction.considerations[i].ScoreConsideration(aiManager);
            score *= curScore;

            if(score == 0)
            {
                curAction.score = 0;
                return curAction.score;
            }
        }


        
        float ogScore = score;
        float modFactor = 1 - (1 / curAction.considerations.Length);
        float makeupValue = (1 - ogScore) * modFactor;
        curAction.score = ogScore + (makeupValue * ogScore);

        return curAction.score;
    }




}
