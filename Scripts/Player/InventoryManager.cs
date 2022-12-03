using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : ManagerClass
{
    public List<Item> items;
    private void Start()
    {
        Inventory inventory = this;

        this.items = new List<Item>();
        string username = myPlayer.username;

        // add bomb-
        string bomb_spriteLoc = "bomb-2-512";
        float bomb_itemLoc = -8.99f;
        float bomb_cd = myPlayer.teleport.cur_tel_cool_down; 
        inventory.items.Add(new Item(myPlayer, "bomb",bomb_spriteLoc, bomb_itemLoc, 0.1f, true,false, username, bomb_cd));

        // add missile-
        string missile_spriteLoc = "missile";
        float missile_pos = -8.24f;
        inventory.items.Add(new Item(myPlayer,"missile", missile_spriteLoc,missile_pos ,0.1f, true, false, username, 0));

        // add lasers
        //string laser_spriteLoc = "lasers";
        //float laser_pos = -7.5f;
        //inventory.items.Add(new Item(myPlayer,"laser", laser_spriteLoc, laser_pos, 0.1f, false, false, username, 0));

        // add teleport cool_down
        string teleport_spriteLoc = "gem/0003";
        //float tele_pos = -6.76f;
        float tele_pos = -7.5f;
        //float bomb_cd = myPlayer.teleport.cur_tel_cool_down;
        inventory.items.Add(new Item(myPlayer, "teleport", teleport_spriteLoc, tele_pos, 1.5f, false, true, username, 0));

        // add shield cool_down
        string speed_spriteLoc = "speed";
        //float speed_pos = -6.01f;
        float speed_pos = -6.76f;
        //float bomb_cd = myPlayer.teleport.cur_tel_cool_down;
        inventory.items.Add(new Item(myPlayer, "speed", speed_spriteLoc, speed_pos, 0.1f, false, true, username, 0));
    }

    // Update is called once per frame
    void Update()
    {
        float curTime = Time.deltaTime;

        items[0].updateAmmoIMG(myPlayer.bombManager.bomb_amt);
        items[1].updateAmmoIMG(myPlayer.missileManager.ammunition);
        items[2].updateCoolDownIMG(curTime);
        items[3].updateCoolDownIMG(curTime);


    }
}

public class Item
{
    Player myPlayer;
    //public bool isPlayer1;
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
    public Item(Player myPlayer, string item_name, string iconSpriteLocation, float item_x_Location, float scale, bool ammo, bool cd, string username, float amount)
    {
        this.myPlayer = myPlayer;
        this.item_x_Location = item_x_Location;

        this.background = new GameObject(item_name + username) ;
        this.blockBG = this.background.AddComponent<SpriteRenderer>();
        this.blockBG.sprite = Resources.Load("HUD/Bars/Spells/Modulable_1", typeof(Sprite)) as Sprite;
        this.blockBG.sortingOrder = 20;
        if (myPlayer.isplayer1())
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
        this.icon.sortingOrder = 22;

        this.maksContainer = new GameObject("mask");
        this.maksContainer.transform.parent = this.background.transform;
        this.maksContainer.AddComponent<Canvas>();
        //this.maksContainer.AddComponent<RectTransform>();

        rt = this.maksContainer.GetComponent<RectTransform>();
        rt.localPosition = new Vector2(0,0);
        rt.sizeDelta = new Vector2(1.2f, 0.9f); 

        // Overlay counter mask, 
        myCanvas = this.maksContainer.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.WorldSpace;
        myCanvas.sortingOrder = 23;
        this.mask = this.maksContainer.AddComponent<Image>();
        this.mask.GetComponent<Image>().color = new Color32(29, 28, 79, 0);

        makeCanvas(5, ammo, cd);
    }

    private void makeCanvas(float cur_text,bool ammo, bool cooldown)
    {
        if (ammo)
        {
            this.mask.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            this.img1 = Resources.Load<Sprite>("sci-fi-effects/yellow_cloud/09");
            this.mask.transform.parent = this.maksContainer.transform;
            this.mask.sprite = img1;
        }

        if (cooldown)
        {
            this.mask.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            this.img1 = Resources.Load<Sprite>("sci-fi-effects/rotating_boxes/d_0004");
            this.mask.transform.parent = this.maksContainer.transform;
            this.mask.sprite = img1;
            this.mask.type = Image.Type.Filled;
            this.mask.fillAmount = 1.00f;
        }
    }

    public void updateAmmoIMG(int amt)
    {
        if (amt >0)
        {
            this.mask.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
           this.mask.GetComponent<Image>().color = new Color32(29, 28, 79, 0);
        }
    }


    public void updateCoolDownIMG(float time)
    {
        float cur_tel_cooldown;
        float tel_cool_down;
        bool isActive;

        if (item_name == "teleport")
        {
            isActive = myPlayer.teleport.getisDropped();
            tel_cool_down = myPlayer.teleport.getCoolDown();
            cur_tel_cooldown = myPlayer.teleport.getCurCoolDown();
            if (isActive)
            {
                float fill = (Time.deltaTime + cur_tel_cooldown) / tel_cool_down;
                //Debug.Log("fill amt=" + fill);
                this.mask.fillAmount = fill;
            }
            else
             {
            this.mask.fillAmount = 1.00f;
            }
        }

        if(item_name == "speed")
        {
            isActive = myPlayer.boostManager.getisActive();
            tel_cool_down = myPlayer.boostManager.getBoostCoolDown();
            cur_tel_cooldown = myPlayer.boostManager.getCurrentBoostCoolDown();
            if (isActive)
            {
                float fill = (Time.deltaTime + cur_tel_cooldown) / tel_cool_down;
                //Debug.Log("fill amt=" + fill);
                this.mask.fillAmount = fill;
            }
            else
            {
                this.mask.fillAmount = 1.00f;
            }
        }
    }


}
