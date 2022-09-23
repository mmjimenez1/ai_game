using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public int epPerSecond;
    public float timeElapsed;
    public bool isActive;
    public bool waitingForDirection;

    private string spritesLocation = "/sci-fi-effects/front_shieldB";

    private Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        waitingForDirection = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= 1)
            {
                timeElapsed--;
                myPlayer.energyManager.minusEP(1);
            }
        }

        Vector2 direction = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.LeftShift) || this.waitingForDirection)
        {
            if (isActive)
            {
                this.isActive = false;
                Debug.Log("Shield disabled");
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                    direction.x--;
                if (Input.GetKey(KeyCode.D))
                    direction.x++;
                if (Input.GetKey(KeyCode.S))
                    direction.y--;
                if (Input.GetKey(KeyCode.W))
                    direction.y++;
                if (direction == Vector2.zero)
                    direction = myPlayer.movementManager.direction;
                Debug.Log(direction);
                if (direction == Vector2.zero)
                {
                    this.waitingForDirection = true;
                }
                else
                {
                    direction.Normalize();
                    this.isActive = true;
                    this.waitingForDirection = false;
                    timeElapsed = 0;
                    Debug.Log("Shield enabled at " + direction.x + ", " + direction.y);
                }
            }
        }
    }

    public void setPlayer(Player p)
    {
        this.myPlayer = p;
    }
}
