using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : ManagerClass
{
    public bool isActive;
    private GameObject bombObject;
    public Bomb bombComponent { get; private set; }

    public int bomb_amt;

    //private int ep_cost;

    // Start is called before the first frame update
    void Start()
    {
        this.isActive = false;
        this.bomb_amt = 5;
    }


    // Update is called once per frame
    void Update()
    {
        updateStatus();
    }

    void updateStatus()
    {
        if (Input.GetKeyDown(myPlayer.controls["Bomb"]))
        {
            if (isActive)
                detonateBomb();
            else
                dropBomb();
        }
    }

    private void createBomb()
    {
        bombObject = new GameObject("Bomb " + myPlayer.username);
        bombComponent = bombObject.AddComponent<Bomb>();
    }

    public void dropBomb()
    {
        if (bomb_amt > 0)
        {
            if (!isActive)
            {
                Vector2 cur_location = myPlayer.gameObject.transform.position;
                print(cur_location);
                createBomb();
                Debug.Log("dropping bomb");
                bombObject.SetActive(true);
                isActive = true;
                bombObject.transform.position = cur_location;
                bomb_amt = bomb_amt - 1;
            }
        }
        else
        {
            Debug.Log("no more bombs to drop");
        }
        
    }

    public void detonateBomb()
    {
        if (isActive)
        {
            Debug.Log("detonating");
            isActive = false;
            bombComponent.activateBomb();
        }
    }

    public void pickUpBomb(int amount)
    {
        this.bomb_amt += amount;
    }

    public int getBombAmt()
    {
        return bomb_amt;
    }
}

