using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UseShield", menuName = "UtilityAI/Actions/UseShield")]
public class UseShield : Action { 
    public override void doAction(AIManager aiManager)
    {
        Debug.Log("activating shield");
        Player p = aiManager.getPlayer();
        p.shieldManager.setActiveShield(true);
        Debug.Log("Using shield");
    }
}
