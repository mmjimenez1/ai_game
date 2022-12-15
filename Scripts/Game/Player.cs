using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string username;
    public GameObject gameObject;
    public SpriteRenderer spriteRenderer;
    //public GameManager gameManager;

    public PlayerManager playerManager;
    public MovementManager movementManager;
    public BoostManager boostManager;
    public teleport teleport;
    public HealthManager healthManager;
    public EnergyManager energyManager;
    public BombManager bombManager;
    public ShieldManager shieldManager;
    public MissileManager missileManager;
    public LaserManager laserManager;
    public AIManager aiManager;
    public UIManager uiManager;
    public Inventory inv;
    public Dictionary<string, KeyCode> controls;

    public Player(string username, string spriteLocation)
    {
        this.username = username;
        this.gameObject = new GameObject("Player " + this.username);
        this.gameObject.tag = "Player";

        this.spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load(spriteLocation, typeof(Sprite)) as Sprite;
        this.spriteRenderer.sortingOrder = 1;

        CircleCollider2D collider = this.gameObject.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
        collider.radius = 0.5f;
        //Rigidbody2D rigid = this.gameObject.AddComponent<Rigidbody2D>();
        //rigid.isKinematic = true;

        this.playerManager = this.gameObject.AddComponent<PlayerManager>();
        this.playerManager.setPlayer(this);
        this.movementManager = this.gameObject.AddComponent<MovementManager>();
        this.movementManager.setPlayer(this);
        this.boostManager = this.gameObject.AddComponent<BoostManager>();
        this.boostManager.setPlayer(this);
        this.teleport = this.gameObject.AddComponent<teleport>();
        this.teleport.setPlayer(this);
        this.bombManager = this.gameObject.AddComponent <BombManager>();
        this.bombManager.setPlayer(this);
        this.healthManager = this.gameObject.AddComponent<HealthManager>();
        this.healthManager.setPlayer(this);
        this.energyManager = this.gameObject.AddComponent<EnergyManager>();
        this.energyManager.setPlayer(this);
        this.shieldManager = this.gameObject.AddComponent<ShieldManager>();
        this.shieldManager.setPlayer(this);
        this.missileManager = this.gameObject.AddComponent<MissileManager>();
        this.missileManager.setPlayer(this);
        this.laserManager = this.gameObject.AddComponent<LaserManager>();
        this.laserManager.setPlayer(this);
        this.uiManager = this.gameObject.AddComponent<UIManager>();
        this.uiManager.setPlayer(this);
        this.inv = this.gameObject.AddComponent<Inventory>();
        this.inv.setPlayer(this);
        this.aiManager = null;

        setDefaultControls();
    }

    public void setControls(Dictionary<string, KeyCode> newControls)
    {
        this.controls = newControls;
    }

    public void setDefaultControls()
    {
        this.controls = new Dictionary<string, KeyCode>()
        {
            { "Left", KeyCode.F},
            { "Right", KeyCode.H},
            { "Down", KeyCode.G},
            { "Up", KeyCode.T},

            { "Alt_Left", KeyCode.None},
            { "Alt_Right", KeyCode.None},
            { "Alt_Down", KeyCode.None},
            { "Alt_Up", KeyCode.None},

            { "Boost", KeyCode.Space},
            { "Bomb", KeyCode.E},
            { "Teleport", KeyCode.Q},
            { "Laser", KeyCode.R},

            { "Shield", KeyCode.Tab},
            { "Missile", KeyCode.LeftShift},
            { "Shield_Left", KeyCode.A},
            { "Shield_Right", KeyCode.D},
            { "Shield_Down", KeyCode.S},
            { "Shield_Up", KeyCode.W}
        };
    }

    public string setUsername(string newUsername)
    {
        this.username = newUsername;
        return this.username;
    }

    public static List<Player> getEnemies(Player p)
    {
        List<Player> enemies = new List<Player>();
        foreach (Player player in GameManager.players)
        {
            if (player.username != p.username)
            {
                enemies.Add(player);
            }
        }
        return enemies;
    }

    public List<Player> getPlayers()
    {
        List<Player> players = new List<Player>();
        foreach (Player player in GameManager.players)
        {
            players.Add(player);
        }
        return players;
    }

    public float getDistanceToPlayer(Player p)
    {
        if (p == null)
            return -1;
        Vector3 pLocation = p.gameObject.transform.position;
        Vector3 myLocation = this.gameObject.transform.position;
        return Vector3.Distance(myLocation, pLocation);
    }

    public Player getClosestPlayer()
    {
        List<Player> enemies = getEnemies(this);
        float min = float.MaxValue;
        Player closest = null;
        foreach(Player p in enemies)
        {
            float distance = getDistanceToPlayer(p);
            if(distance < min)
            {
                min = distance;
                closest = p;
            }
        }
        return closest;
    }

    public bool isplayer1()
    {
        return username == "Player1";
    }

    public void setUpAI(Action[] possibleActions, Action[] movementActions)
    {
        this.aiManager = this.gameObject.AddComponent<AIManager>();
        aiManager.possibleActions = possibleActions;
        aiManager.movementActions = movementActions;
        aiManager.brain = this.gameObject.AddComponent<AIBrain>();
        this.aiManager.setPlayer(this);
    }
}

public class PlayerManager : ManagerClass
{
    public Player GetPlayer()
    {
        return myPlayer;
    }
}