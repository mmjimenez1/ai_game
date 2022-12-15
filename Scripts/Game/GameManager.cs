using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AI Brain ->
//
public class GameManager : MonoBehaviour
{
    public static List<Player> players;
    public static Dictionary<string, Player> playerDictionary;
    public static GameManager gameManager;

    public UIManager uIManager;
    //public Timer timer;
    public StationBehavior stationBehavior;
    public HealthStation healthStation;
    public EnergyStation energyStation;
    public BombStation bombStation;
    public GameObject canvas;

    // AI actions
    public Action[] possibleActions;
    public Action[] movementActions;

    //public List<Vector2> listBombLocations;
    //public Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        //startGame(false);
    }

    public void startGame(bool twoPlayer)
    {
        canvas.SetActive(false);
        gameManager = this;
        //uIManager = this.gameObject.AddComponent<UIManager>();
        //timer = this.gameObject.AddComponent<Timer>();
        //inv = this.gameObject.AddComponent<Inventory>();
        players = new List<Player>
        {
            new Player("Player1", "neptune"),
            new Player("Player2", "jupiter")
        };
        players.ForEach(p => {
            //p.gameManager = this;
            if (p.username == "Player1")
                p.uiManager.isPlayer1 = true;
            //p.inv.isplayer1 = true;
            if (p.username == "Player2")
            {
                if(!twoPlayer)
                    p.setUpAI(possibleActions, movementActions);
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

                    { "Shield", KeyCode.Comma},
                    //{ "Missile", KeyCode.I},
                    { "Shield_Left", KeyCode.L},
                    { "Shield_Right", KeyCode.Quote},
                    { "Shield_Down", KeyCode.Semicolon},
                    { "Shield_Up", KeyCode.P}
                });
            }
        });
        stationBehavior = this.gameObject.AddComponent<StationBehavior>();
        stationBehavior.healthStation = healthStation;
        stationBehavior.energyStation = energyStation;
        stationBehavior.bombStation = bombStation;

        playerDictionary = GetPlayerDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        //findWinner();
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

    private string findWinner()
    {
        List<Player> winners = players;
        for (int i = 0; i < winners.Count; i++)
        {
            Player p = winners[i];
            //Debug.Log("checking for winenrs");
            if (p.healthManager.getHealthPoints() == 0)
            {
                winners.Remove(p);
                Debug.Log(winners[0].username);
            }
            
        }
        string winner = winners[0].username;
        Debug.Log(winner);
        return winner;
      
    }

    //public List<Vector2> getBombLocation(){
    //        List<Vector2> bombs = null;
    //        foreach (Player p in players)
    //        {
    //            if (p.bombManager.isActive)
    //            {
    //                bombs.Add(p.bombManager.bombLocation);
    //            }
    //        }
    //        Debug.Log("bombs = " + bombs);
    //        return bombs;
    // }

 }
