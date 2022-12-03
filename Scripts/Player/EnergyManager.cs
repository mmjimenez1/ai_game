using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : ManagerClass
{
    [SerializeField]
    private int energyPoints;
    [SerializeField]
    private int energyCap;
    public int regenerationPerSecond;
    private float regenerationTimeElapsed;

    //private Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.energyCap = 100;
        this.energyPoints = energyCap;
        this.regenerationPerSecond = 1;
        this.regenerationTimeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        regenerateEnergy();
    }

    void regenerateEnergy()
    {
        regenerationTimeElapsed += Time.deltaTime;
        if(regenerationTimeElapsed > 1)
        {
            regenerationTimeElapsed--;
            plusEP(regenerationPerSecond);
        }
    }

    public int getEnergyPoints()
    {

        return energyPoints;
    }

    public int getEnergyCap()
    {
        return energyCap;
    }

    public int minusEP(int cost)
    {
        if (cost < 0)
            return this.energyPoints;
        this.energyPoints -= cost;
        if (this.energyPoints < 0)
            this.energyPoints = 0;
        return energyPoints;
    }

    public int plusEP(int ep)
    {
        if(ep < 0)
            return this.energyPoints;
        this.energyPoints += ep;
        if (this.energyPoints > energyCap)
            this.energyPoints = energyCap;
        return energyPoints;
    }

    public bool isEnough(int ep)
    {
        return ep <= this.energyPoints;
    }

    public void resetHealthPoints()
    {
        this.energyPoints = energyCap;
    }

    //public void setPlayer(Player p)
    //{
    //    this.myPlayer = p;
    //}
}
