using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players;
    public UIManager uIManager;
    public Timer timer;
    public StationBehavior station;
    //public Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = this.gameObject.AddComponent<UIManager>();
        //timer = this.gameObject.AddComponent<Timer>();
        //inv = this.gameObject.AddComponent<Inventory>();
        players = new List<Player>();
        this.players.Add(new Player("Player1", "neptune"));
        this.players.Add(new Player("Player2", "jupiter"));
        players.ForEach(p => {
            Debug.Log(p.username);
            p.gameManager = this;
            if (p.username == "Player1")
                p.uiManager.isPlayer1 = true;
                //p.inv.isplayer1 = true;
            if (p.username == "Player2")
            {
                p.uiManager.isPlayer1 = false;
                //p.inv.isplayer1 = false;
                p.setControls(new Dictionary<string, KeyCode>()
                {
                    { "Left", KeyCode.LeftArrow},
                    { "Right", KeyCode.RightArrow},
                    { "Down", KeyCode.DownArrow},
                    { "Up", KeyCode.UpArrow},

                    { "Alt_Left", KeyCode.Keypad4},
                    { "Alt_Right", KeyCode.Keypad6},
                    { "Alt_Down", KeyCode.Keypad5},
                    { "Alt_Up", KeyCode.Keypad8},

                    { "Boost", KeyCode.RightShift},
                    { "Bomb", KeyCode.LeftBracket },
                    { "Teleport", KeyCode.O},
                    { "Laser", KeyCode.RightBracket},

                    { "Shield", KeyCode.I},
                    { "Missile", KeyCode.Comma},
                    { "Shield_Left", KeyCode.L},
                    { "Shield_Right", KeyCode.Quote},
                    { "Shield_Down", KeyCode.Semicolon},
                    { "Shield_Up", KeyCode.P}
                });
            }
        });
        station = this.gameObject.AddComponent<StationBehavior>();
        station.lisPlayers = players;

    }

    // Update is called once per frame
    void Update()
    {
       

    }


 }
