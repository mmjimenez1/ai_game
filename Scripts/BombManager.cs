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
    //private Sprite[] sprites;
    //private int currentSprite;
    //public int fps;
    //private float flunctuationTime;

    Vector2 node_location;

    // Start is called before the first frame update
    void Start()
    {
        bomb_location = "bomb";
        this.bombObject = new GameObject("bomb " + myPlayer.username);
        this.spriteRenderer = this.bombObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load(bomb_location, typeof(Sprite)) as Sprite;
        //currentSprite = 0;
        //this.spriteRenderer.sprite = sprites[currentSprite];
        this.bombObject.transform.localScale = new Vector2(3f, 3f);
        this.bombObject.SetActive(false);

        isActive = false;
        isDetonated = false;



    }

    // Update is called once per frame
    void Update()
    {
        node_location = myPlayer.gameObject.transform.position;
        dropBomb(node_location);

    }

    // drop bomb decrease energy
    void dropBomb(Vector2 cur_location)
    {
        if (!isActive && Input.GetKeyDown(myPlayer.controls["Bomb"]))
        {
            isDetonated = false;
            Debug.Log("dropping bomb");
            bombObject.SetActive(true);
            isActive = true;
            this.transform.position = cur_location;
            activateBomb();

        }


    }

    void activateBomb()
    {
        if(isActive && Input.GetKeyDown(myPlayer.controls["Bomb"]))
        {
            Debug.Log("detonating");
            isDetonated = true;
            bombObject.SetActive(false);
            isActive = false;

        }
        
    }

    


}
