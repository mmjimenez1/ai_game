using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string username;
    public GameObject gameObject;
    public SpriteRenderer spriteRenderer;

    public MovementManager movementManager;
    public BoostManager dashManager;
    public teleport teleport;
    public HealthManager healthManager;
    public EnergyManager energyManager;
    public BombManager explosion;
    public ShieldManager shieldManager;
    public MissileManager missileManager;

    public Dictionary<string, KeyCode> controls;

    public Player(string username, string spriteLocation)
    {
        this.username = username;
        this.gameObject = new GameObject("Player " + this.username);

        this.spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load(spriteLocation, typeof(Sprite)) as Sprite;
        this.spriteRenderer.sortingOrder = 1;

        this.movementManager = this.gameObject.AddComponent<MovementManager>();
        this.movementManager.setPlayer(this);
        this.dashManager = this.gameObject.AddComponent<BoostManager>();
        this.dashManager.setPlayer(this);
        this.teleport = this.gameObject.AddComponent<teleport>();
        this.teleport.setPlayer(this);
        this.explosion = this.gameObject.AddComponent <BombManager>();
        this.explosion.setPlayer(this);
        this.healthManager = this.gameObject.AddComponent<HealthManager>();
        this.healthManager.setPlayer(this);
        this.energyManager = this.gameObject.AddComponent<EnergyManager>();
        this.energyManager.setPlayer(this);
        this.shieldManager = this.gameObject.AddComponent<ShieldManager>();
        this.shieldManager.setPlayer(this);
        this.missileManager = this.gameObject.AddComponent<MissileManager>();
        this.missileManager.setPlayer(this);

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
            { "Left", KeyCode.G},
            { "Right", KeyCode.J},
            { "Down", KeyCode.H},
            { "Up", KeyCode.Y},

            { "Alt_Left", KeyCode.LeftArrow},
            { "Alt_Right", KeyCode.RightArrow},
            { "Alt_Down", KeyCode.DownArrow},
            { "Alt_Up", KeyCode.UpArrow},

            { "Boost", KeyCode.Space},
            { "Bomb", KeyCode.E},
            { "Teleport", KeyCode.Q},

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
}
