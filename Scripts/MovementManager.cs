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
        MoveManager();
    }

    void MoveManager()
    {
        direction = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.LeftArrow))
            direction.x--;
        if (Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.RightArrow)) 
            direction.x++;
        if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.DownArrow))
            direction.y--;
        if(Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.UpArrow))
            direction.y++;

        direction.Normalize();
        Vector2 pos = this.transform.position;
        pos.x += direction.x * speed * Time.deltaTime;
        pos.y += direction.y * speed * Time.deltaTime;
        this.transform.position = pos;
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
