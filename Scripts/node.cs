using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public GameObject gameObject;
    //teleport t = new teleport();
    Vector2 pos;

    bool is_dropped;


    // Start is called before the first frame update
    void Start()
    {
        teleport teleport_object = new teleport();
        this.gameObject.AddComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("gem", typeof(Sprite)) as Sprite;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        is_dropped = t.getStatus();


        if (is_dropped)
        {
            pos = t.getPostition();
            set_sprite(pos);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }

    }

    void set_sprite(Vector2 cur_pos)
    {
        this.gameObject.AddComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("gem", typeof(Sprite)) as Sprite;
        gameObject.GetComponent<SpriteRenderer>().transform.position = cur_pos;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;


    }

}
