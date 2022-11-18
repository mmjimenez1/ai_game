using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBehavior : ManagerClass
{
    private SpriteRenderer stationImg;
    private GameObject stationObject;
    private Vector2 station_pos;
    public bool isHealth;
    private int waitTime;
    private float counter;
    private bool isSpawned;
    public List<Player> lisPlayers;



    // Start is called before the first frame update
    void Start()
    {

        this.stationObject = new GameObject("station");
        this.stationImg = this.stationObject.AddComponent<SpriteRenderer>();
        this.stationImg.sprite = Resources.Load("sci-fi-effects/rotators/rotator1B", typeof(Sprite)) as Sprite;
        this.stationImg.sortingOrder = 3;
        this.counter = 0;
        this.waitTime = 5;
        this.isSpawned = false;

    }
   
    void Update()
    {
        if (isSpawned)
        {
            increaseHealth();
            //Debug.Log("station spawned");
        }
        else
        {
            spawnStation();
        }       
    }

    void spawnStation()
    {
        Vector2 pos = new Vector2(4.69f, -0.32f);
        this.stationObject.transform.position = pos;
        this.station_pos = pos;
        this. isSpawned = true;
        counter = waitTime;
        
    }

    void increaseHealth()
    {
        for (int i = 0; i < lisPlayers.Count; i++)
        {
            Player p = lisPlayers[i];
            Vector2 playerPos = p.gameObject.transform.position;
            if (Vector2.Distance(playerPos, station_pos) < 0.4)
            {
                p.healthManager.plusHP(10);
            }

        }
    }




}
