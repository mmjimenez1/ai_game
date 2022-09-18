using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10.0f;
    private float initialSpeed = 10.0f;
    public float dashFactor = 3.0f;
    public float dashCooldown = 5.0f;
    public float currentDashCooldown;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
        currentDashCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hello");
        DashManager();
        MovementManager();
    }

    void DashManager()
    {
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
    }

    void MovementManager()
    {
        Vector3 pos = this.transform.position;
        if (Input.GetKey(KeyCode.A))
            pos.x -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            pos.x += speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            pos.y -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            pos.y += speed * Time.deltaTime;

        this.transform.position = pos;
    }
}
