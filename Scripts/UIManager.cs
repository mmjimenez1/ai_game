
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : ManagerClass
{
    public GUISkin guiSkin;
    public GameObject maskPrefab;
    public GameObject maskObject;

    public GameObject maskPrefab2;
    public GameObject maskObject2;

    Rect windowRect = new Rect(0, 0, 400, 380);
    bool toggleTxt = false;
    string stringToEdit = "Text Label";
    string textToEdit = "TextBox:\nHello World\nI've got few lines...";
  

    //private SpriteRenderer srEOutline;
    private SpriteRenderer srEBlue;
    private SpriteRenderer srEBackground;

    //private SpriteRenderer srHOutline;
    private SpriteRenderer srHRed;
    private SpriteRenderer srHBackground;


    private GameObject energyBlue;
    private GameObject energyBackground;
    private GameObject energyOutline;

    private GameObject healthRed;
    private GameObject healthBackground;
    private GameObject healthOutline;

    private Vector2 mask_pos;
    private Vector2 mask_pos2;

    private Vector2 player2Pos;
    private Vector2 startMaskPos;
    private Vector2 startMaskPos2;

    public bool isPlayer1;

    private GameObject uiContainer;


    // Start is called before the first frame update
    void Start()
    {
        mask_pos= new Vector2(-6.62f, 4.75f);
        mask_pos2 = new Vector2(-6.62f, 3.55f);

        player2Pos = new Vector2();
        guiSkin = Resources.Load("Sci-FiUI/_SciFi_GUISkin_/SciFi_Skin") as GUISkin;
        windowRect.x = (Screen.width - windowRect.width) / 2;
        windowRect.y = (Screen.height - windowRect.height) / 2;

        this.uiContainer = new GameObject("UIContainer" + myPlayer.username);


        this.maskPrefab = Resources.Load("Prefabs/sMask") as GameObject;
        this.maskObject = Instantiate(this.maskPrefab, mask_pos, Quaternion.identity);
        this.maskObject.transform.parent = this.uiContainer.transform;

        this.maskPrefab2 = Resources.Load("Prefabs/sMask") as GameObject;
        this.maskObject2 = Instantiate(this.maskPrefab2, mask_pos2, Quaternion.identity);
        this.maskObject2.transform.parent = this.uiContainer.transform;


        this.energyBlue = new GameObject("EnergyBlue" + myPlayer.username);
        //this.energyOutline = new GameObject("EnergyContainer" + myPlayer.username);
        this.energyBackground = new GameObject("EnergyBG" + myPlayer.username);
        this.healthRed = new GameObject("Health Red" + myPlayer.username);
        this.healthBackground = new GameObject("Health BG");

        this.energyBlue.transform.parent = this.uiContainer.transform;
        this.energyBackground.transform.parent = this.uiContainer.transform;
        this.healthRed.transform.parent = this.uiContainer.transform;
        this.healthBackground.transform.parent = this.uiContainer.transform;


        // sprites for energy bar
        this.srEBlue = this.energyBlue.AddComponent<SpriteRenderer>();
        this.srEBlue.sprite = Resources.Load("HUD/Bars/Exp/2", typeof(Sprite)) as Sprite;
        this.srEBlue.sortingOrder = 11;
        this.srEBlue.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        this.srEBackground = this.energyBackground.AddComponent<SpriteRenderer>();
        this.srEBackground.sprite = Resources.Load("HUD/Bars/Exp/background2", typeof(Sprite)) as Sprite;
        this.srEBackground.sortingOrder = 10;


        // sprites for health bar
        this.srHRed = this.healthRed.AddComponent<SpriteRenderer>();
        this.srHRed.sprite = Resources.Load("HUD/Bars/Exp/3", typeof(Sprite)) as Sprite;
        this.srHRed.sortingOrder = 11;
        this.srHRed.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        this.srHBackground = this.healthBackground.AddComponent<SpriteRenderer>();
        this.srHBackground.sprite = Resources.Load("HUD/Bars/Exp/background2", typeof(Sprite)) as Sprite;
        this.srHBackground.sortingOrder = 10;

        if (isPlayer1)
        {
            this.energyBlue.transform.localPosition = new Vector2(-6.58f, 3.95f);
            this.energyBackground.transform.localPosition = new Vector2(-6.58f, 3.95f);
           
            this.healthRed.transform.localPosition = new Vector2(-6.58f, 4.38f);
            this.healthBackground.transform.localPosition = new Vector2(-6.58f, 4.38f);
        }
        else
        {
            //this.srEOutline.flipX = true;
            this.srEBlue.flipX = true;
            this.srEBackground.flipX = true;

            this.energyBlue.transform.localPosition = new Vector2(6.65f, 3.95f);
            this.energyBackground.transform.localPosition = new Vector2(6.65f, 3.95f);
            this.maskObject.transform.localPosition = new Vector2(6.65f, 4.75f);
            this.maskObject2.transform.localPosition = new Vector2(6.65f, 3.55f);


            this.healthRed.transform.localPosition = new Vector2(6.65f, 4.38f);
            this.healthBackground.transform.localPosition = new Vector2(6.65f, 4.38f);
        }
        this.startMaskPos = this.maskObject.transform.position;
        this.startMaskPos2 = this.maskObject2.transform.position;


        //this.energyBackground.transform.localScale = new Vector2(0.6914f, 0.514325f);


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

        float cur_health = myPlayer.healthManager.getHealthPoints();
        float health_cap = myPlayer.healthManager.getHealthCap();
        float current_x = startMaskPos.x;
        float scale_x = maskObject.transform.localScale.x;
        float deltaX = (1 - cur_health / health_cap);

        float cur_energy = myPlayer.energyManager.getEnergyPoints();
        float energy_cap = myPlayer.energyManager.getEnergyCap();
        float cur_x_e = startMaskPos2.x;
        float scale_x_e = maskObject2.transform.localScale.x;
        float deltaXE = (1 - cur_energy / energy_cap);

        if (isPlayer1) {
            current_x -= deltaX * scale_x;
            cur_x_e -= deltaXE * scale_x_e;
        }
        else
        {   
            current_x += deltaX * scale_x;
            cur_x_e += deltaXE * scale_x_e;
        }
        print(myPlayer.username + ": " + current_x);
        maskObject.transform.position = new Vector2(current_x, startMaskPos.y);
        maskObject2.transform.position = new Vector2(cur_x_e, startMaskPos2.y);



    }
}
