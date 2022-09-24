using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : ManagerClass
{
    public int epPerSecond;
    public float timeElapsed;
    public bool isActive;
    public bool waitingForDirection;

    public GameObject shieldObject;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private string spritesLocation;

    //private Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        waitingForDirection = false;

        this.shieldObject = new GameObject("Shield " + myPlayer.username);
        this.shieldObject.transform.parent = myPlayer.gameObject.transform;
        this.shieldObject.transform.localPosition = new Vector2(0, 0.35f);
        this.shieldObject.transform.localScale = new Vector2(0.45f, 0.35f);
        this.shieldObject.transform.localRotation = Quaternion.identity;

        spritesLocation = "sci-fi-effects/front_shieldB";
        this.spriteRenderer = this.shieldObject.AddComponent<SpriteRenderer>();
        this.sprites = Resources.LoadAll<Sprite>(spritesLocation);
        Debug.Log(this.sprites.Length);
        this.spriteRenderer.sprite = this.sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= 1)
            {
                timeElapsed--;
                myPlayer.energyManager.minusEP(1);
            }
        }

        Vector2 direction = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.LeftShift) || this.waitingForDirection)
        {
            if (isActive)
            {
                this.isActive = false;
                Debug.Log("Shield disabled");
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                    direction.x--;
                if (Input.GetKey(KeyCode.D))
                    direction.x++;
                if (Input.GetKey(KeyCode.S))
                    direction.y--;
                if (Input.GetKey(KeyCode.W))
                    direction.y++;
                if (direction == Vector2.zero)
                    direction = myPlayer.movementManager.direction;
                Debug.Log(direction);
                if (direction == Vector2.zero)
                {
                    this.waitingForDirection = true;
                }
                else
                {
                    direction.Normalize();
                    this.isActive = true;
                    this.waitingForDirection = false;
                    this.timeElapsed = 0;
                    Debug.Log("Shield enabled at " + direction.x + ", " + direction.y);
                    float angle = Vector3.Angle(Vector3.up, new Vector3(direction.x, direction.y, 0));
                    //this.shieldObject.transform.Rotate(new Vector3(0, 0, angle));   
                }
            }
        }
    }

    //public void setPlayer(Player p)
    //{
    //    this.myPlayer = p;
    //}
}
