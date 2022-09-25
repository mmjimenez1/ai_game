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

    // Start is called before the first frame update
    void Start()
    {
        boostFactor = 3.0f;
        boostCooldown = 5.0f;
        currentBoostCooldown = 0f;
        boostDuration = 1f;
        epCost = 5;
    }

    // Update is called once per frame
    void Update()
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

        if (Input.GetKeyDown(myPlayer.controls["Boost"]))
        {
            if (currentBoostCooldown <= 0f && myPlayer.energyManager.isEnough(epCost))
            {
                myPlayer.energyManager.minusEP(epCost);
                speed += initialSpeed * boostFactor;
                currentBoostCooldown = boostCooldown;
            }
        }
        myPlayer.movementManager.speed = speed;
    }

}
