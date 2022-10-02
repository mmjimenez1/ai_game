using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : ManagerClass
{
    public GUISkin guiSkin;
    public GameObject maskPrefab;
    public GameObject maskObject;

    Rect windowRect = new Rect(0, 0, 400, 380);
    bool toggleTxt = false;
    string stringToEdit = "Text Label";
    string textToEdit = "TextBox:\nHello World\nI've got few lines...";
    //float hSliderValue = 0.0f;
    //float vSliderValue = 0.0f;
    //float hSbarValue;
    //float vSbarValue;
    //Vector2 scrollPosition = Vector2.zero;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;
    private SpriteRenderer spriteRenderer3;
    private GameObject healthBlue;
    private GameObject healthBackground;
    private GameObject healthOutline;
    private Vector2 mask_pos;
    private Vector2 player2Pos;
        

    public bool isPlayer1;
    private Vector2 startMaskPos;


    private GameObject uiContainer;


    // Start is called before the first frame update
    void Start()
    {
        mask_pos= new Vector2(-6.62f, 3.63f);
        player2Pos = new Vector2();
        guiSkin = Resources.Load("Sci-FiUI/_SciFi_GUISkin_/SciFi_Skin") as GUISkin;
        windowRect.x = (Screen.width - windowRect.width) / 2;
        windowRect.y = (Screen.height - windowRect.height) / 2;

        this.uiContainer = new GameObject("UIContainer" + myPlayer.username);


        this.maskPrefab = Resources.Load("Prefabs/sMask") as GameObject;
        this.maskObject = Instantiate(this.maskPrefab, mask_pos, Quaternion.identity);
        this.maskObject.transform.parent = uiContainer.transform;


        this.healthBlue = new GameObject("HealthBlue" + myPlayer.username);
        this.healthOutline = new GameObject("HealthContainer" + myPlayer.username);
        this.healthBackground = new GameObject("HealthBG" + myPlayer.username);

        this.healthBlue.transform.parent = this.uiContainer.transform;
        this.healthOutline.transform.parent = this.uiContainer.transform;
        this.healthBackground.transform.parent = this.uiContainer.transform;


        this.spriteRenderer = this.healthOutline.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load("Border_0", typeof(Sprite)) as Sprite;
        this.spriteRenderer.sortingOrder = 12;
        this.healthOutline.transform.localScale = new Vector2(0.6914f, 0.514325f);


        this.spriteRenderer2 = this.healthBlue.AddComponent<SpriteRenderer>();
        this.spriteRenderer2.sprite = Resources.Load("Health_0", typeof(Sprite)) as Sprite;
        this.spriteRenderer2.sortingOrder = 11;
        this.healthBlue.transform.localScale = new Vector2(0.6914f, 0.514325f);
        this.spriteRenderer2.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        this.spriteRenderer3 = this.healthBackground.AddComponent<SpriteRenderer>();
        this.spriteRenderer3.sprite = Resources.Load("Health_1", typeof(Sprite)) as Sprite;
        this.spriteRenderer3.sortingOrder = 10;

        if (isPlayer1)
        {
            this.healthOutline.transform.localPosition = new Vector2(-6.53f, 3.52f);
            this.healthBlue.transform.localPosition = new Vector2(-6.54f, 3.52f);
            this.healthBackground.transform.localPosition = new Vector2(-6.54f, 3.52f);
        }
        else
        {
            this.spriteRenderer.flipX = true;
            this.spriteRenderer2.flipX = true;
            this.spriteRenderer3.flipX = true;

            this.healthOutline.transform.localPosition = new Vector2(6.9f, 3.52f);
            this.healthBlue.transform.localPosition = new Vector2(6.9f, 3.52f);
            this.healthBackground.transform.localPosition = new Vector2(6.9f, 3.52f);
            this.maskObject.transform.localPosition = new Vector2(7f, 3.52f);

        }
        this.startMaskPos = this.maskObject.transform.position;


        this.healthBackground.transform.localScale = new Vector2(0.6914f, 0.514325f);


    }

    void OnGUI()
    {
        GUI.skin = guiSkin;
        //windowRect = GUI.Window(0, windowRect, DoMyWindow, "Play Game");
    }


    void DoMyWindow(int windowID)
    {

        //GUI.Box(new Rect(10, 50, 120, 250), "hi");
        GUI.Label(new Rect(20, 60, 100, 20), "Player Name: ");
        GUI.Button(new Rect(20, 130, 100, 20), "Save");

        stringToEdit = GUI.TextField(new Rect(15, 90, 110, 20), stringToEdit, 25);
        //hSliderValue = GUI.HorizontalSlider(new Rect(15, 175, 110, 30), hSliderValue, 0.0f, 10.0f);

        //vSliderValue = GUI.VerticalSlider(new Rect(140, 50, 20, 200), vSliderValue, 100.0f, 0.0f);


        toggleTxt = GUI.Toggle(new Rect(165, 50, 100, 30), toggleTxt, "Instructions: ");
        textToEdit = GUI.TextArea(new Rect(165, 90, 185, 100), textToEdit, 200);

        //GUI.Label(new Rect(180, 215, 100, 20), "ScrollView");
        //scrollPosition = GUI.BeginScrollView(new Rect(180, 235, 160, 100), scrollPosition, new Rect(0, 0, 220, 200));
        GUI.Button(new Rect(20, 10, 100, 20), "X");
        //GUI.Button(new Rect(120, 10, 100, 20), "Top-right");
        //GUI.Button(new Rect(0, 170, 100, 20), "Bottom-left");
        //GUI.Button(new Rect(120, 170, 100, 20), "Bottom-right");
        GUI.EndScrollView();

        GUI.Button(new Rect(150, 300, 100, 20), "Start");

        //hSbarValue = GUI.HorizontalScrollbar(new Rect(10, 360, 360, 30), hSbarValue, 5.0f, 0.0f, 10.0f);
        //vSbarValue = GUI.VerticalScrollbar(new Rect(380, 25, 30, 300), vSbarValue, 1.0f, 30.0f, 0.0f);


        //GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }


    // Update is called once per frame
    void Update()
    {   

        float cur_health = myPlayer.energyManager.getEnergyPoints();
        float health_cap = myPlayer.energyManager.getEnergyCap();
        float current_x = startMaskPos.x;
        float scale_x = maskObject.transform.localScale.x;
        float deltaX = (1 - cur_health / health_cap);
        if (isPlayer1) {
            current_x -= deltaX * scale_x;
        }
        else
        {   
            current_x += deltaX * scale_x;
        }
        print(myPlayer.username + ": " + current_x);
        maskObject.transform.position = new Vector2(current_x, startMaskPos.y);



    }
}
