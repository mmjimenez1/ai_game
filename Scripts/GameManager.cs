using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players;
    public UIManager uIManager;
    public Timer timer;
    //public Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = this.gameObject.AddComponent<UIManager>();
        timer = this.gameObject.AddComponent<Timer>();
        //inv = this.gameObject.AddComponent<Inventory>();
        players = new List<Player>();
        this.players.Add(new Player("Player1", "neptune"));
        this.players.Add(new Player("Player2", "jupiter"));
        players.ForEach(p => {
            Debug.Log(p.username);
            p.gameManager = this;
            if (p.username == "Player1")
                p.uiManager.isPlayer1 = true;
                p.inv.isplayer1 = true;
            if (p.username == "Player2")
            {
                p.uiManager.isPlayer1 = false;
                p.inv.isplayer1 = true;
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
                    { "Bomb", KeyCode.LeftBracket },
                    //{ "Bomb", KeyCode.E },
                    { "Teleport", KeyCode.O},

                    { "Shield", KeyCode.I},
                    { "Missile", KeyCode.Comma},
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
        //if (timer.isTimeRunning())
        //{
        //}

    }

 }
