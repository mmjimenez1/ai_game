using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<Player>();
        this.players.Add(new Player("Player1", "neptune"));
        this.players.Add(new Player("Player2", "jupiter"));
        players.ForEach(p => {
            Debug.Log(p.username);
            if(p.username == "Player2")
            {
                p.setControls(new Dictionary<string, KeyCode>()
                {
                    { "Left", KeyCode.Keypad4},
                    { "Right", KeyCode.Keypad6},
                    { "Down", KeyCode.Keypad5},
                    { "Up", KeyCode.Keypad8},

                    { "Alt_Left", KeyCode.None},
                    { "Alt_Right", KeyCode.None},
                    { "Alt_Down", KeyCode.None},
                    { "Alt_Up", KeyCode.None},

                    { "Boost", KeyCode.RightShift},
                    { "Teleport", KeyCode.O},

                    { "Shield", KeyCode.Comma},
                    { "Shield_Left", KeyCode.L},
                    { "Shield_Right", KeyCode.Quote},
                    { "Shield_Down", KeyCode.Semicolon},
                    { "Shield_Up", KeyCode.P}
                });
            }
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
