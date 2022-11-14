using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : ManagerClass
{
    public List<Item> items;
    public bool isplayer1;

    private void Start()
    {
        Inventory inventory = this;

        this.items = new List<Item>();
        bool player1 = isplayer1;
        string username = myPlayer.username;

        // add bomb-
        string bomb_spriteLoc = "bomb-2-512";
        float bomb_itemLoc = -8.99f;
        float bomb_cd = myPlayer.teleport.cur_tel_cool_down; 
        inventory.items.Add(new Item("bomb", bomb_spriteLoc, bomb_itemLoc, 0.1f, false,false, username, bomb_cd));

        // add missile-
        string missile_spriteLoc = "missile";
        float missile_pos = -8.24f;
        inventory.items.Add(new Item("missile", missile_spriteLoc,missile_pos ,0.1f, false, false, username, 0));

        // add lasers
        string laser_spriteLoc = "laser";
        float laser_pos = -7.5f;
        inventory.items.Add(new Item("laser", laser_spriteLoc, laser_pos, 0.1f, false, true, username, 0));

        // add teleport cool_down
        string teleport_spriteLoc = "gem/0003";
        float tele_pos = -6.76f;
        //float bomb_cd = myPlayer.teleport.cur_tel_cool_down;
        inventory.items.Add(new Item("teleport", teleport_spriteLoc, tele_pos, 1.5f, false, true, username, 0));

        // add shield cool_down
        string shield_spriteLoc = "shield";
        float shield_pos = -6.01f;
        //float bomb_cd = myPlayer.teleport.cur_tel_cool_down;
        inventory.items.Add(new Item("shield", shield_spriteLoc, shield_pos, 0.19f, false, true, username, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Item
{
    public bool isPlayer1;
    public string item_name;
    private float item_x_Location;

    public GameObject maksContainer;
    public GameObject iconContainer;
    public GameObject background;

    private SpriteRenderer blockBG;
    private SpriteRenderer icon;
    private RectTransform rt;
    private Image mask;
    public Canvas myCanvas;
    private Sprite img1;

    public bool isAmmo;
    public bool isCoolDown;
    
    // constructor-
    public Item(string item_name, string iconSpriteLocation, float item_x_Location, float scale, bool ammo, bool cd, string username, float amount)
    {
        
        this.item_x_Location = item_x_Location;

        this.background = new GameObject(item_name + username) ;
        this.blockBG = this.background.AddComponent<SpriteRenderer>();
        this.blockBG.sprite = Resources.Load("HUD/Bars/Spells/Modulable_1", typeof(Sprite)) as Sprite;

        if (username == "Player1")
        {
            this.background.transform.localPosition = new Vector2(item_x_Location,3.19f);
        }
        else
        {
            item_x_Location = -1.00f * item_x_Location;  
            this.background.transform.localPosition = new Vector2(item_x_Location, 3.19f);


        }

        // icon-
        this.item_name = item_name;
        this.iconContainer = new GameObject(this.item_name);
        this.icon = this.iconContainer.AddComponent<SpriteRenderer>();
        this.icon.sprite = Resources.Load(iconSpriteLocation, typeof(Sprite)) as Sprite;
        this.iconContainer.transform.parent = this.background.transform;
        this.iconContainer.transform.localScale = new Vector2(scale, scale);
        this.iconContainer.transform.localPosition = new Vector2(0, 0);
        this.icon.sortingOrder = 1;

        this.maksContainer = new GameObject("mask");
        this.maksContainer.transform.parent = this.background.transform;
        this.maksContainer.AddComponent<Canvas>();
        this.maksContainer.AddComponent<RectTransform>();

        rt = this.maksContainer.GetComponent<RectTransform>();
        rt.localPosition = new Vector2(0,0);
        rt.sizeDelta = new Vector2(1.2f, 0.9f); 

        // Overlay counter mask, 
        myCanvas = this.maksContainer.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.WorldSpace;
        myCanvas.sortingOrder = 3;
        this.mask = this.maksContainer.AddComponent<Image>();
        this.mask.GetComponent<Image>().color = new Color32(29, 28, 79, 0);

      

    }


    private void makeCanvas(float cur_text,bool ammo, bool cooldown)
    {

        if (ammo)
        {

        }

        if (cooldown)
        {
            this.mask.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            this.img1 = Resources.Load<Sprite>("sci-fi-effects/rotating_boxes/d_0004");
            this.mask.transform.parent = this.maksContainer.transform;
            this.mask.sprite = img1;
            this.mask.type = Image.Type.Filled;
            if(cur_text < 0.0f)
            {
                this.mask.fillAmount = 0.00f;

            }
            else
            {
                this.mask.fillAmount = 1.00f;
            }

        }
    }


}
