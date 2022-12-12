using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : ManagerClass
{
    public float boostFactor;
    public float boostCooldown;
    public float currentBoostCooldown;
    public float boostDuration;
    public int epCost;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        boostFactor = 3.0f;
        boostCooldown = 5.0f;
        currentBoostCooldown = 0f;
        boostDuration = 1f;
        epCost = 5;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        normalizeSpeed();
        if (Input.GetKeyDown(myPlayer.controls["Boost"]))
        {
            Boost();
            isActive = true;
        }
    }

    void normalizeSpeed()
    {
        float speed = myPlayer.movementManager.speed;
        float initialSpeed = myPlayer.movementManager.getInitialSpeed();

        if (speed > initialSpeed)
            speed -= initialSpeed * boostFactor * Time.deltaTime * (1 / boostDuration);
        if (speed < initialSpeed)
            speed = initialSpeed;

        if (currentBoostCooldown > 0f)
            currentBoostCooldown -= Time.deltaTime;
        else
            currentBoostCooldown = 0f;
        myPlayer.movementManager.speed = speed;
    }

    public void Boost()
    {
        if (currentBoostCooldown <= 0f && myPlayer.energyManager.isEnough(epCost))
        {
            myPlayer.energyManager.minusEP(epCost);
            myPlayer.movementManager.speed += myPlayer.movementManager.getInitialSpeed() * boostFactor;
            currentBoostCooldown = boostCooldown;
        }
    }

    public bool isAvailable()
    {
        if (currentBoostCooldown <= 0f && myPlayer.energyManager.isEnough(epCost))
            return true;
        else
            return false;
    }

    public float getBoostCoolDown()
    {
        return boostCooldown;
    }


    public float getCurrentBoostCoolDown()
    {
        return currentBoostCooldown;
    }

    public bool getisActive()
    {
        return isActive;
    }
}
