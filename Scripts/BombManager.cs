using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

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
    public int bomb_amt;
    public float explosionRadius;

    Vector2 node_location;

    //private int ep_cost;

    // Start is called before the first frame update
    void Start()
    {
        bomb_location = "bomb";
        sprite_loc = "sci-fi-effects/explosion";
        this.sprites = Resources.LoadAll<Sprite>(sprite_loc);
        this.bomb_amt = 5;
        this.explosionRadius = 3.0f;

        isActive = false;
        isDetonated = false;
        fps = 16;
        //ep_cost = 10;


    }


    // Update is called once per frame
    void Update()
    {

        if (isDetonated)// why is this in update smh
        {
            updateSprite();
            float radius = 5.00f;
            int damage = 10;

            checkRadius(node_location,radius ,damage);
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

    private void updateSprite()
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

    private void createBomb()
    {
        this.bombObject = new GameObject("bomb " + myPlayer.username);
        this.spriteRenderer = this.bombObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load(bomb_location, typeof(Sprite)) as Sprite;
        this.bombObject.transform.localScale = new Vector2(0.092023f, 0.07978807f);
        //this.bombObject.SetActive(false);
    }

    private void dropBomb(Vector2 cur_location)
    {
        //if (myPlayer.energyManager.isEnough(ep_cost))
        //{
        if (bomb_amt > 0)
        {
            if (!isActive && Input.GetKeyDown(myPlayer.controls["Bomb"]))
            {
                print(cur_location);
                createBomb();
                this.bombObject.transform.localScale = new Vector2(0.092023f, 0.07978807f);
                isDetonated = false;
                Debug.Log("dropping bomb");
                bombObject.SetActive(true);
                isActive = true;
                bombObject.transform.position = cur_location;
                this.bomb_amt = this.bomb_amt - 1;
                //myPlayer.energyManager.minusEP(ep_cost);


            }
        }
        else
        {
            Debug.Log("no more bombs to drop");
        }
        //}
        //else
        //{
        //    Debug.Log("not enough energy for dropping bombs");
        //}
        
    }

    private void activateBomb()
    {
        if (isActive && Input.GetKeyDown(myPlayer.controls["Bomb"]))
        {
            Debug.Log("detonating");
            isDetonated = true;
            isActive = false;
            currentSprite = 0;
            this.bombObject.transform.localScale = new Vector2(2, 2);
            this.spriteRenderer.sprite = sprites[currentSprite];

            List<Player> enemies = myPlayer.getEnemies(myPlayer);
            foreach(Player p in enemies)
            {
                Vector2 playerPos = p.gameObject.transform.position;
                Vector2 bombPos = bombObject.transform.position;
                if(Vector2.Distance(playerPos, bombPos) < explosionRadius)
                {
                    p.healthManager.minusHP(32);
                }

            }
            Destroy(bombObject, 0.5f);


            //bombObject.SetActive(false);


        }
    }

     private void checkRadius(Vector2 location, float radius, int dmgAmt)
    {
            // this is not needed
    }

    public int getBombAmt()
    {
        return bomb_amt;
    }


    public void uBombAmt(int amt)
    {
        bomb_amt = amt;
    }



}

