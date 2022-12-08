using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Consideration : ScriptableObject
{
    public string considerationName;
    public float totalScore;

    public float score
    {
        get { return totalScore; }
        set { this.totalScore = Mathf.Clamp01(value); }
    }

    public virtual void Awake()
    {
        score = 0;
    }

    public abstract float ScoreConsideration(AIManager aiManager);
}
