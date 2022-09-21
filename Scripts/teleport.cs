using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] GameObject node1;

    //public float pos_x;
    //public float pos_y;

    // Start is called before the first frame update
    void Start()
    {
        node1_pos = node1.transform.position;
        //node2_pos = node2.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = new Vector2(pos_x, pos_y);

    }
}
