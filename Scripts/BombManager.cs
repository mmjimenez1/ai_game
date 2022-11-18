using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class BombManager : ManagerClass
{
    public bool isActive;
    private GameObject bombObject;
    private Bomb bombComponent;

    public int bomb_amt;

    //private int ep_cost;

    // Start is called before the first frame update
    void Start()
    {
        this.isActive = false;
        this.bomb_amt = 50;
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
                activateBomb();
            else
                dropBomb();
        }
    }

    private void createBomb()
    {
        bombObject = new GameObject("Bomb " + myPlayer.username);
        bombComponent = bombObject.AddComponent<Bomb>();
    }

    private void dropBomb()
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

    private void activateBomb()
    {
        if (isActive)
        {
            Debug.Log("detonating");
            isActive = false;
            bombComponent.activateBomb();
        }
    }


    // uh hi
    public int getBombAmt()
    {
        return bomb_amt;
    }


    // tf is this
    public void uBombAmt(int amt)
    {
        bomb_amt = amt;
    }



}

