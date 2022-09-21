using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    Vector2 node_location;
    public bool is_dropped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if pressed q and have not dropped node
        if (Input.GetKey(KeyCode.Q) && is_dropped == false )
        {
            if (is_dropped)
            {
                teleport_object(node_location);
                is_dropped = false;
                //node_location = null;
            }
            else
            {
               
                // store that cur location
                node_location = this.transform.position;
                is_dropped = true;
            }
            
        }

        //gameObject.transform.position = new Vesctor2(pos_x, pos_y);

    }

    void teleport_object(Vector2 i_location)
    {
        this.transform.position = i_location;
    }
}
