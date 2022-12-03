using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : ManagerClass
{
    [SerializeField]
    private int healthPoints;
    [SerializeField]
    private int healthCap;

    // Start is called before the first frame update
    void Start()
    {
        this.healthCap = 100;
        this.healthPoints = healthCap;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getHealthPoints()
    {
        return healthPoints;
    }

    public int getHealthCap()
    {
        return healthCap;
    }

    public int minusHP(int dmg)
    {
        this.healthPoints -= dmg;
        if (this.healthPoints < 0)
            this.healthPoints = 0;
        return healthPoints;
    }

    public int plusHP(int hp)
    {
        this.healthPoints += hp;
        if (this.healthPoints > healthCap)
            this.healthPoints = healthCap;
        return healthPoints;
    }

    public void resetHealthPoints()
    {
        this.healthPoints = healthCap;
    }

    //public void setPlayer(Player p)
    //{
    //    this.myPlayer = p;
    //}
}
