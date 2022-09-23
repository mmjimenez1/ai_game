using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashManager : ManagerClass
{
    public float dashFactor = 3.0f;
    public float dashCooldown = 5.0f;
    public float currentDashCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentDashCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = myPlayer.movementManager.speed;
        float initialSpeed = myPlayer.movementManager.getInitialSpeed();

        if (speed > initialSpeed)
            speed -= initialSpeed * dashFactor * Time.deltaTime;
        else
            speed = initialSpeed;

        if (currentDashCooldown > 0f)
            currentDashCooldown -= Time.deltaTime;
        else
            currentDashCooldown = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentDashCooldown <= 0f)
            {
                speed += initialSpeed * dashFactor;
                currentDashCooldown = dashCooldown;
            }
        }
        myPlayer.movementManager.speed = speed;
    }

}
