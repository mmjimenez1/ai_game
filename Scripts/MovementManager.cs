using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementManager : ManagerClass
{
    public float speed = 15.0f;
    public float baseSpeed = 15.0f;
    public Vector2 direction;

    NavMeshAgent agent;

    //private Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0f, 0f);
        baseSpeed = speed;

        agent = GetComponent<NavMeshAgent>();
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
        if (Input.GetMouseButton(0) && myPlayer.username == "Player1")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 mousePos = ray.origin;
            Vector2 pos = this.transform.position;
            direction = mousePos - pos;
            //print("Mouse position: " + mousePos);
            if (direction.magnitude < 0.1f)
                direction = new Vector2(0f, 0f);
        }
        else
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
        }
        direction.Normalize();
    }

    public float getInitialSpeed()
    {
        return baseSpeed;
    }

    //public void setPlayer(Player p)
    //{
    //    this.myPlayer = p;
    //}
}
