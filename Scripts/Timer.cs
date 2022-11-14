using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class Timer : ManagerClass
{
    public GUISkin guiSkin;
    private GUIStyle guiStyle = new GUIStyle();
    private int x;
    private int y;

    //private string toggleTxt;

    public GameObject timerObject;
    private SpriteRenderer circleBg;
    private GameObject timerContainer;
    public GameObject text;

    public float timeRemaining = 60.00f;
    public string timerText;
    private bool isRunning= true;
    // Start is called before the first frame update
    void Start()
    {
        guiSkin = Resources.Load("Sci-FiUI/_SciFi_GUISkin_/SciFi_Skin") as GUISkin;

        this.timerContainer = new GameObject("timer");
        Vector2 timerPos = new Vector2(0.00f, 3.45f);
        this.timerObject = new GameObject("circleBG");
        this.timerObject.transform.parent = this.timerContainer.transform;

        this.circleBg = this.timerObject.AddComponent<SpriteRenderer>();
        this.circleBg.sprite = Resources.Load("sci-fi-effects/explosion/0008", typeof(Sprite)) as Sprite;
        this.timerContainer.transform.position = timerPos;
        //this.timerText.text = string.Format("{}", timeRemaining);

    }

    void OnGUI()
    {
        guiStyle.alignment = TextAnchor.UpperCenter;

        GUI.skin = guiSkin;
        guiStyle.fontSize = 65; //change the font size
        guiStyle.normal.textColor = Color.white;
        Rect position = new Rect((Screen.width-50)/2, 30, 100, 200);
        int cur_time = (int) timeRemaining;
        string timeText = cur_time.ToString();
        GUI.Label(position, timeText, guiStyle);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                this.timeRemaining -= Time.deltaTime;
                //this.timerText.text = string.Format("{}", timeRemaining);
            }
            else
            {
                this.timeRemaining = 0;
                this.isRunning = false;
            }
        }
        
    }

    public bool isTimeRunning()
    {
        return isRunning;
    }

    
}
