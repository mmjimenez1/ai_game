using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : ManagerClass
{
    public bool isActive;
    public bool isDetonated;
    
    private GameObject bombObject;

    private SpriteRenderer spriteRenderer;
    private string bomb_location;
    private Sprite[] sprites;
    private string sprite_loc;
    private int currentSprite;
    public int fps;
    private float flunctuationTime;

    Vector2 node_location;

    private int ep_cost;

    // Start is called before the first frame update
    void Start()
    {
        bomb_location = "bomb";
        

        sprite_loc = "sci-fi-effects/explosion";
        this.sprites = Resources.LoadAll<Sprite>(sprite_loc);


        isActive = false;
        isDetonated = false;
        fps = 16;
        ep_cost = 10;


    }


    // Update is called once per frame
    void Update()
    {
        if (isDetonated)
        {
            updateSprite();
        }

        node_location = myPlayer.gameObject.transform.position;
        if (isActive)
        {
            activateBomb();
        }
        else
        {
            dropBomb(node_location);
        }


    }

    void updateSprite()
    {
        Debug.Log("explosion");

        flunctuationTime += Time.deltaTime;
        float fluctuationFrequency = 1f / fps;
        if (flunctuationTime > fluctuationFrequency)
        {
            currentSprite++;
            if (currentSprite == this.sprites.Length)
            {
                isDetonated = false;
                return;
            }
            flunctuationTime -= fluctuationFrequency;
            this.spriteRenderer.sprite = this.sprites[currentSprite];
        }

    }

    void createBomb()
    {
        this.bombObject = new GameObject("bomb " + myPlayer.username);
        this.spriteRenderer = this.bombObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load(bomb_location, typeof(Sprite)) as Sprite;
        this.bombObject.transform.localScale = new Vector2(.3f, .3f);
        //this.bombObject.SetActive(false);
    }

    void dropBomb(Vector2 cur_location)
    {
        if (myPlayer.energyManager.isEnough(ep_cost))
        {
            if (!isActive && Input.GetKeyDown(myPlayer.controls["Bomb"]))
            {
                print(cur_location);
                createBomb();
                this.bombObject.transform.localScale = new Vector2(.3f, .3f);
                isDetonated = false;
                Debug.Log("dropping bomb");
                bombObject.SetActive(true);
                isActive = true;
                bombObject.transform.position = cur_location;
                myPlayer.energyManager.minusEP(ep_cost);


            }
        }
        else
        {
            Debug.Log("not enough energy for dropping bombs");
        }
        
    }

    void activateBomb()
    {
        if(isActive && Input.GetKeyDown(myPlayer.controls["Bomb"]))
        {
            Debug.Log("detonating");
            isDetonated = true;
            isActive = false;
            currentSprite = 0;
            this.bombObject.transform.localScale = new Vector2(1, 1);
            this.spriteRenderer.sprite = sprites[currentSprite];
            Destroy(bombObject, 0.5f);


            //bombObject.SetActive(false);


        }

    }

    


}
