using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager: MonoBehaviour
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




}
