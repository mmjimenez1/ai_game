using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : ManagerClass
{
    // teleport stuff
    Vector2 node_location;
    public bool is_dropped = false;
    public float tel_cool_down = 5.0f;
    public float cur_tel_cool_down;
    public float timeElapsed;

    public int epPerSecond;

    // teleport node
    public Sprite[] sprites;
    private string sprite_loc;
    public GameObject teleportObject;
    public SpriteRenderer spriteRenderer;
    private int cur_sprite;

    public int fps;
    public float flunctuation_time;

    // Start is called before the first frame update
    void Start()
    {
        sprite_loc = "gem";

        this.teleportObject = new GameObject("node " + myPlayer.username);
        this.spriteRenderer = this.teleportObject.AddComponent<SpriteRenderer>();
        this.sprites = Resources.LoadAll<Sprite>(sprite_loc);
        cur_sprite = 0;
        this.spriteRenderer.sprite = sprites[cur_sprite];
        this.teleportObject.SetActive(false);
        this.spriteRenderer.sortingOrder = 0;
        this.teleportObject.transform.localScale = new Vector2(3f,3f);
        cur_tel_cool_down = 0f;
        is_dropped = false;

        fps = 15;
    }

    // fix so it continues spinning after teleporting
    // fix cool down so it starts after teleported to the location
    // Update is called once per frame
    void Update()
    {
        if (is_dropped)
        {
            teleportObject.SetActive(true);

            flunctuation_time += Time.deltaTime;
            float flunctuationFrequency = 1f / fps;

            if(flunctuation_time > flunctuationFrequency)
            {
                cur_sprite++;
                if (cur_sprite >= sprites.Length)
                {
                    cur_sprite = 0;
                }
                    this.spriteRenderer.sprite = sprites[cur_sprite];
                }
            
        }
        else
        {
            teleportObject.SetActive(false);

        }
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
                    //teleportObject.SetActive(true);
                    is_dropped = false;
                    //timeElapsed = 0; 
                    Debug.Log("storing cur pos");
                    cur_tel_cool_down = tel_cool_down;
                    Debug.Log("cooling..");
                }
            }
            else
            {

                node_location = myPlayer.gameObject.transform.position;
                teleportObject.transform.position = node_location;
                //teleportObject.SetActive(false);
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