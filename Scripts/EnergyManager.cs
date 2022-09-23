using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : ManagerClass
{
    [SerializeField]
    private int energyPoints;
    [SerializeField]
    private int energyCap;

    //private Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.energyCap = 100;
        this.energyPoints = energyCap;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int minusEP(int cost)
    {
        this.energyPoints -= cost;
        if (this.energyPoints < 0)
            this.energyPoints = 0;
        return energyPoints;
    }

    public int plusEP(int ep)
    {
        this.energyPoints += ep;
        if (this.energyPoints > energyCap)
            this.energyPoints = energyCap;
        return energyPoints;
    }

    //public void setPlayer(Player p)
    //{
    //    this.myPlayer = p;
    //}
}
