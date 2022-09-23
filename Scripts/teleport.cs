using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : ManagerClass
{
    Vector2 node_location;
    public bool is_dropped = false;
    //public bool isActive;
    public float tel_cool_down = 5.0f;
    public float cur_tel_cool_down;
    public float timeElapsed;
    public int epPerSecond;

    public Sprite[] sprites;
    private string sprite_loc;
    public GameObject gameObject;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        sprite_loc = "gem";
        cur_tel_cool_down = 0f;
        is_dropped = false;
        //isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // decrease cool_down counter
        if (cur_tel_cool_down > 0f)
        {
            cur_tel_cool_down -= Time.deltaTime;
        }
        else
        {
            cur_tel_cool_down = 0f;
        }

        if (is_dropped)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 1)
            {
                timeElapsed--;
                myPlayer.energyManager.minusEP(epPerSecond);
            }
        }

        // if pressed q and have not dropped node
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (is_dropped)
            {


                if (cur_tel_cool_down <= 0f)
                {
                    teleport_object(node_location);
                    is_dropped = false;
                    //timeElapsed = 0; 
                    Debug.Log("storing cur pos");
                    cur_tel_cool_down = tel_cool_down;
                    Debug.Log("cooling..");
                }
            }
            else
            {

                // store that cur location
                node_location = this.transform.position;
                this.spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
                this.sprites = Resources.LoadAll<Sprite>(sprite_loc);
                this.spriteRenderer.sprite = sprites[0];
                //set_sprite(node_location);
                is_dropped = true;
                timeElapsed = 0;



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