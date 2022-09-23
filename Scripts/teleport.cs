using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    Vector2 node_location;
    public bool is_dropped = false;
    public float tel_cool_down = 10.0f;
    public float cur_tel_cool_down;

    // Start is called before the first frame update
    void Start()
    {
        cur_tel_cool_down= 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // decrease cool_down counter
        if (cur_tel_cool_down > 0f)
        {
            cur_tel_cool_down -= Time.deltaTime;
        }
        else{
            cur_tel_cool_down = 0f;
        }

        
        // if pressed q and have not dropped node
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (is_dropped)
            {
                
                Debug.Log("Dropped");
                if (cur_tel_cool_down <= 0f)
                {
                    teleport_object(node_location);
                    is_dropped = false;
                    Debug.Log("storing cur pos");
                    cur_tel_cool_down = tel_cool_down;
                    Debug.Log("cooling..");
                }
            }
            else
            {

                // store that cur location
                node_location = this.transform.position;
                //set_sprite(node_location);
                is_dropped = true;

            }

        }
    }

    public bool getStatus()
    {
        return is_dropped;
    }

    public Vector2 getPostition()
    {
        return this.transform.position;

    }

    void teleport_object(Vector2 i_location)
    {
        Debug.Log("teleporting");
        this.transform.position = i_location;
    }
}
