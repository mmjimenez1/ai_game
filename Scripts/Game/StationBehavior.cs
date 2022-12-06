using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBehavior : ManagerClass
{
    public HealthStation healthStation { get; set; }
    public EnergyStation energyStation { get; set; }
    public BombStation bombStation { get; set; }

    //private SpriteRenderer stationImg;
    //private SpriteRenderer healthImg;
    //private GameObject stationObject;
    //private GameObject healthObject;


    //public bool isUsed;
    //public bool isActive;

    //public List<Player> lisPlayers;
    //public Vector2 station_pos;

    //public float waitTime;
    //public float duration;
    //public float curTime;
    //public float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        this.healthStation.setUp();
        this.energyStation.setUp();
        this.bombStation.setUp();
        //this.stationObject = healthStation.container;
        //this.healthObject = new GameObject("Item");

        //this.healthObject.transform.parent = this.stationObject.transform;
        //this.healthObject.transform.localScale = new Vector2(0.05510619f, 0.05510619f);
        //this.stationImg = this.stationObject.AddComponent<SpriteRenderer>();
        //this.healthImg = this.healthObject.AddComponent<SpriteRenderer>();
        ////this.stationImg.sprite = Resources.Load("sci-fi-effects/rotators/rotator1B", typeof(Sprite)) as Sprite;
        ////this.healthImg.sprite = Resources.Load("health", typeof(Sprite)) as Sprite;
        //this.stationImg.sprite = healthStation.containerSprite;
        //this.healthImg.sprite = healthStation.itemSprite;

        //this.stationImg.sortingOrder = 3;
        //this.healthImg.sortingOrder = 5;

        //this.stationImg.color = healthStation.containerColor;

        //this.isUsed = false;
        //this.isActive = false;
        //this.waitTime = 15.0f;
        //this.duration = 5f;
        //this.timeElapsed = 0f;
        //this.curTime = healthStation.waitTime;

        //this.stationObject.SetActive(false);
        //this.stationObject.transform.position = station_pos;

    }
   
    void Update()
    {
        healthStation.updateStatus();
        energyStation.updateStatus();
        bombStation.updateStatus();
        //if (!isActive)
        //{
        //    updateStationStatus();
        //}
        //else
        //{
        //    if( timeElapsed <= 0 || this.isUsed)
        //    {
        //        despawn();  
        //    }
        //    else 
        //    {
        //        this.timeElapsed -= Time.deltaTime;
        //        increaseHealth();
        //    }
        //}
    }

    //void updateStationStatus()
    //{
    //    if (curTime > 0)
    //    {
    //        this.curTime -= Time.deltaTime;
    //    }
    //    else
    //    {
    //        this.curTime = 0f;
    //        makeStation();
    //    }
    //}

    //void makeStation()
    //{
    //    Vector2 station_pos = new Vector2(Random.Range(-9f, 9f), Random.Range(-4.50f, 4.50f));
    //    isUsed = false;
    //    timeElapsed = healthStation.duration;
    //    healthStation.container.transform.position = station_pos;
    //    healthStation.container.SetActive(true);
    //    //this.stationObject.transform.position = station_pos;
    //    //this.stationObject.SetActive(true);
    //}

    //void despawn()
    //{
    //    isActive = false;
    //    curTime = healthStation.waitTime;
    //    healthStation.container.SetActive(false);
    //    //this.stationObject.SetActive(false);
    //}

    //void increaseHealth()
    //{
    //    lisPlayers = GameManager.players;
    //    for (int i = 0; i < lisPlayers.Count; i++)
    //    {
    //        Player p = lisPlayers[i];
    //        Vector2 playerPos = p.gameObject.transform.position;
    //        if (Vector2.Distance(playerPos, station_pos) < 0.4)
    //        {
    //            Debug.Log("increasing health");
    //            p.healthManager.plusHP(10);
    //            isUsed = true;

    //        }
    //    }
    //}
}

