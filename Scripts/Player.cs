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
    public ShieldManager shieldManager;

    public Dictionary<string, KeyCode> controls;

    public Player(string username)
    {
        this.username = username;
        this.gameObject = new GameObject("Player " + this.username);

        this.spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load("jupiter", typeof(Sprite)) as Sprite;
        this.spriteRenderer.sortingOrder = 1;

        this.movementManager = this.gameObject.AddComponent<MovementManager>();
        this.movementManager.setPlayer(this);
        this.dashManager = this.gameObject.AddComponent<BoostManager>();
        this.dashManager.setPlayer(this);
        this.teleport = this.gameObject.AddComponent<teleport>();
        this.teleport.setPlayer(this);
        this.healthManager = this.gameObject.AddComponent<HealthManager>();
        this.healthManager.setPlayer(this);
        this.energyManager = this.gameObject.AddComponent<EnergyManager>();
        this.energyManager.setPlayer(this);
        this.shieldManager = this.gameObject.AddComponent<ShieldManager>();
        this.shieldManager.setPlayer(this);

        this.controls = new Dictionary<string, KeyCode>()
        {
            { "Left", KeyCode.J},
            { "Right", KeyCode.L},
            { "Down", KeyCode.K},
            { "Up", KeyCode.I},

            { "Alt_Left", KeyCode.LeftArrow},
            { "Alt_Right", KeyCode.RightArrow},
            { "Alt_Down", KeyCode.DownArrow},
            { "Alt_Up", KeyCode.UpArrow},

            { "Boost", KeyCode.Space},
            { "Teleport", KeyCode.Q},

            { "Shield", KeyCode.LeftShift},
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
