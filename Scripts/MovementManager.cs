using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : ManagerClass
{
    public float speed = 10.0f;
    private float initialSpeed = 10.0f;
    public Vector2 direction;

    //private Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0f, 0f);
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        updateDirection();
        MoveManager();
    }

    void MoveManager()
    {
        Vector2 pos = this.transform.position;
        pos.x += direction.x * speed * Time.deltaTime;
        pos.y += direction.y * speed * Time.deltaTime;
        this.transform.position = pos;
    }

    void updateDirection()
    {
        direction = new Vector2(0f, 0f);
        if (Input.GetKey(myPlayer.controls["Left"]) || Input.GetKey(myPlayer.controls["Alt_Left"]))
            direction.x--;
        if (Input.GetKey(myPlayer.controls["Right"]) || Input.GetKey(myPlayer.controls["Alt_Right"]))
            direction.x++;
        if (Input.GetKey(myPlayer.controls["Down"]) || Input.GetKey(myPlayer.controls["Alt_Down"]))
            direction.y--;
        if (Input.GetKey(myPlayer.controls["Up"]) || Input.GetKey(myPlayer.controls["Alt_Up"]))
            direction.y++;
        direction.Normalize();
    }

    public float getInitialSpeed()
    {
        return initialSpeed;
    }

    //public void setPlayer(Player p)
    //{
    //    this.myPlayer = p;
    //}
}
