using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string username;
    public GameObject gameObject;
    public MovementManager movementManager;

    public Player(string username)
    {
        this.username = username;




        this.gameObject = new GameObject("Player " + this.username);
        this.gameObject.AddComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("jupiter", typeof(Sprite)) as Sprite;



        this.gameObject.AddComponent<MovementManager>();
    }
}
