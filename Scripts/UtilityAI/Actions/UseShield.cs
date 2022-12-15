using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UseShield", menuName = "UtilityAI/Actions/UseShield")]
public class UseShield : Action { 
    public override void doAction(AIManager aiManager)
    {

        aiManager.doUseShield();
        //Debug.Log("activating shield");
        //Player p = ai.getPlayer();
        //p.shieldManager.setActiveShield(true);
        //Debug.Log("Using shield");
        //ai.onFinishedAction();

        //// Wait for 5 seconds.
        //yield return new WaitForSeconds(5);

        //// After 5 seconds, print a message to the console.
        //Debug.Log("Action complete!");

    }

    
}
