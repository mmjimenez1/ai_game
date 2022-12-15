using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public AIBrain brain { get; set; }
    public Action[] possibleActions;
    public GameObject myObject;

    public GameManager gameManager;
    //public Player p;
    //public ScriptableObject[] myArray = new ScriptableObject[5];

    private void Start()
    {
        Debug.Log("starting ai manager");
        brain = GetComponent<AIBrain>();
        myObject = GameObject.Find("GameManager");

        if (gameManager == null)
        {
            // If it is null, print a message to the console.
            Debug.Log("My object is not set!");
            gameManager = myObject.GetComponent<GameManager>();
            // You can also handle the null case here by initializing the object
            // or taking some other appropriate action.
        }

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
        return gameManager.getAIPlayer();
    }


    public void GrabBomb()
    {
        //StartCoroutine(GrabBomb)
    }


    IEnumerator useShield()
    {
        Debug.Log("activating shield");
        Player p = getPlayer();

        if(p.shieldManager.isShieldActive() != true)
        {
            p.shieldManager.setActiveShield(true);
            Debug.Log("Using shield");

        }

        // Wait for 3 seconds.
        yield return new WaitForSeconds(3);

        // After 3 seconds, print a message to the console.
        Debug.Log("Action complete!");

        if (p.shieldManager.isShieldActive() == true)
        {
            p.shieldManager.setActiveShield(false);
            Debug.Log("stopping shield");

        }
        yield break;
    }

    public void doUseShield()
    {
        StartCoroutine(useShield());
        onFinishedAction();

    }


}
