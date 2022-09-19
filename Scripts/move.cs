using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 10.0f;
    private float initial_speed;

    private float dash_factor = 5.0f;
    public float elapsed_time;
    public float elapsed_time_in_dash;
    public float time_in_dash = 5;

    // Start is called before the first frame update
    void Start()
    {
        initial_speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        Dash_Manager();
        Movement_Manager();
      
    }

    void Dash_Manager()
    {
        elapsed_time += Time.deltaTime;
        if (elapsed_time_in_dash > 0)
        {
            elapsed_time_in_dash -= Time.deltaTime;
        }
        else
        {
            elapsed_time_in_dash = 0;
            speed = initial_speed;
        }
        //elapsed_time_in_dash += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {

            if (elapsed_time_in_dash <= 0.0f)
            {
                elapsed_time_in_dash = time_in_dash;
                speed = speed * dash_factor;
                Debug.Log("Dash...");

            }

        }
    }

    void Movement_Manager()
    {
        Vector2 m = this.transform.position;

        //if (elapsed_time > 0.5)
        //{
        //    speed = initial_speed;
        //}


        if (Input.GetKey(KeyCode.W))
        {
            m.y += speed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.A))
        {
            m.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m.x += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m.y -= speed * Time.deltaTime;
        }

        this.transform.position = m;
    }
}
