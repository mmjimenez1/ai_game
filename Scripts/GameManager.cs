using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<Player> players;
    public static Dictionary<string, Player> playerDictionary;

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
        players.Add(new Player("Player1", "neptune"));
        players.Add(new Player("Player2", "jupiter"));
        players.ForEach(p => {
            //p.gameManager = this;
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

        playerDictionary = GetPlayerDictionary();
    }

    private Dictionary<string, Player> GetPlayerDictionary()
    {
        Dictionary<string, Player> dict = new Dictionary<string, Player>();
        foreach (Player p in players)
        {
            dict.Add(p.username, p);
        }
        return dict;
    }

    // Update is called once per frame
    void Update()
    {
       

    }


 }
