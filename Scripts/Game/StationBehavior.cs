using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBehavior : ManagerClass
{
    private SpriteRenderer stationImg;
    private SpriteRenderer healthImg;
    private GameObject stationObject;
    private GameObject healthObject;

   
    public bool isUsed;
    public bool isActive;

    public List<Player> lisPlayers;
    private Vector2 station_pos;

    public float waitTime;
    public float duration;
    public float curTime;
    public float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        this.stationObject = new GameObject("station");
        this.healthObject = new GameObject("health");
        this.healthObject.transform.parent = this.stationObject.transform;
        this.healthObject.transform.localScale = new Vector2(0.05510619f, 0.05510619f);
        this.stationImg = this.stationObject.AddComponent<SpriteRenderer>();
        this.healthImg = this.healthObject.AddComponent<SpriteRenderer>();
        this.stationImg.sprite = Resources.Load("sci-fi-effects/rotators/rotator1B", typeof(Sprite)) as Sprite;
        this.healthImg.sprite = Resources.Load("health", typeof(Sprite)) as Sprite;

        this.stationImg.sortingOrder = 3;
        this.healthImg.sortingOrder = 5;

        this.station_pos = new Vector2(4.69f, -0.32f);
        this.stationImg.color = new Color32(255, 0, 0, 255);
  
        this.isUsed = false;
        this.isActive = false;
        this.waitTime = 15.0f;
        this.duration = 5f;
        this.timeElapsed = 0f;
        this.curTime = waitTime;

        this.stationObject.SetActive(false);
        this.stationObject.transform.position = station_pos;

    }
   
    void Update()
    {
        if (!isActive)
        {
            if (curTime > 0) 
            {
                this.curTime -= Time.deltaTime;
                //Debug.Log("count down: " + curTime);
            }
            else 
            {
                this.curTime = 0f;
                makeStation();
            }
        }
        else
        {
            if( timeElapsed<= 0 || this.isUsed)
            {
                despawn();  
            }
            else 
            {
                this.timeElapsed -= Time.deltaTime;
                increaseHealth();
            }
        }
    }

    void makeStation()
    {
        this.station_pos = new Vector2(Random.Range(-9f, 9f), Random.Range(-4.50f, 4.50f));
        this.isUsed = false;
        this.isActive = true;
        this.timeElapsed = duration;
        //Debug.Log("making station");
        this.stationObject.transform.position = station_pos;
        this.stationObject.SetActive(true);
    }

    void despawn()
    {
        //Debug.Log("Despawning at etime" + timeElapsed);
        this.isActive = false;
        this.curTime = waitTime;
        this.stationObject.SetActive(false);
    }

    void increaseHealth()
    {
        lisPlayers = GameManager.players;
        for (int i = 0; i < lisPlayers.Count; i++)
        {
            Player p = lisPlayers[i];
            Vector2 playerPos = p.gameObject.transform.position;
            if (Vector2.Distance(playerPos, station_pos) < 0.4)
            {
                Debug.Log("increasing health");
                p.healthManager.plusHP(10);
                isUsed = true;

            }
        }
    }

}

