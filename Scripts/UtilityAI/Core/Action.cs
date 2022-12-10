using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Action : ScriptableObject
{
    public string actionName;
    public float bestScore;

    public float score
    {
        get { return bestScore; }
        set { this.bestScore = Mathf.Clamp01(value); }
    }

    public Consideration[] considerations;

    public virtual void Awake()
    {
        score = 0;
    }
    public abstract void doAction(AIManager aiManager);
}
