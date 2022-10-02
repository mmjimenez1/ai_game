using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : ManagerClass
{
    [SerializeField]
    private int healthPoints;
    [SerializeField]
    private int healthCap;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;
    private GameObject healthObject;
    private GameObject healthContainer;


    //private Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.healthContainer = new GameObject("HealthContainer" + myPlayer.username);
        this.healthObject = new GameObject("Health" + myPlayer.username);

        this.spriteRenderer = this.healthContainer.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load("Border_0", typeof(Sprite)) as Sprite;
        this.healthContainer.transform.localPosition = new Vector2(-6.53f, 3.52f);
        this.healthContainer.transform.localScale = new Vector2(0.6914f, 0.514325f);


        this.spriteRenderer2 = this.healthObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer2.sprite = Resources.Load("Health_0", typeof(Sprite)) as Sprite;
        this.healthObject.transform.localPosition = new Vector2(-6.54f, 3.52f);
        this.healthObject.transform.localScale = new Vector2(0.6914f, 0.514325f);



        this.healthCap = 100;
        this.healthPoints = healthCap;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int minusHP(int dmg)
    {
        this.healthPoints -= dmg;
        if (this.healthPoints < 0)
            this.healthPoints = 0;
        return healthPoints;
    }

    public int plusHP(int hp)
    {
        this.healthPoints += hp;
        if (this.healthPoints > healthCap)
            this.healthPoints = healthCap;
        return healthPoints;
    }

    //public void setPlayer(Player p)
    //{
    //    this.myPlayer = p;
    //}
}
