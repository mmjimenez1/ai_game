using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : ManagerClass
{
    private bool isActive;
    private bool isDetonated;
    
    private GameObject bombObject;

    private SpriteRenderer spriteRenderer;
    private string bomb_location;
    private Sprite[] sprites;
    private int currentSprite;
    public int fps;
    private float flunctuationTime;

    Vector2 node_location;

    // Start is called before the first frame update
    void Start()
    {
        bomb_location = "directory";
        this.bombObject = new GameObject("bomb " + myPlayer.username);
        this.spriteRenderer = this.bombObject.AddComponent<SpriteRenderer>();
        this.sprites = Resources.LoadAll<Sprite>(bomb_location);
        currentSprite = 0;
        this.spriteRenderer.sprite = sprites[currentSprite];
        this.bombObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // drop bomb decrease energy
    //
    void dropBomb()
    {
        isActive = true;



    }

    //p
    void activateBomb()
    {
        if(isActive && Input.GetKeyDown(myPlayer.controls["Bomb"]))
        {
            isDetonated = true;
            isActive = false;

        }
        
    }

    


}
