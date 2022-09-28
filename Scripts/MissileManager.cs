using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : ManagerClass
{
    public GameObject missileContainer;
    public GameObject missileObject;
    public GameObject missilePrefab;

    public int ammunition;
    public bool inPreparation;
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    public float rotationSpeed;

    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int currentSprite;
    public int framesPerSecond;
    private float fluctuationTime;
    private string spritesLocation;

    // Start is called before the first frame update
    void Start()
    {
        this.missileContainer = new GameObject("MissileAimContainer" + myPlayer.username);
        this.missileContainer.transform.parent = myPlayer.gameObject.transform;

        this.missileObject = Instantiate(Resources.Load("Prefabs/Missile") as GameObject, Vector3.zero, Quaternion.identity);
        this.missileObject.name = "MissileAim " + myPlayer.username;

        this.missileObject.transform.parent = missileContainer.transform;
        this.missileObject.transform.localPosition = new Vector2(0, 1);
        this.missileObject.transform.localScale = new Vector2(0.3f, 0.3f);

        this.targetRotation = this.missileContainer.transform.rotation;
        this.rotationSpeed = 0.1f;
        ammunition = 2;
        inPreparation = false;
        missileContainer.SetActive(false);

        this.framesPerSecond = 15;
        this.currentSprite = 0;
        this.spritesLocation = "sci-fi-effects/rotating_shield";
        if (this.missileObject.GetComponent<SpriteRenderer>() == null)
            this.spriteRenderer = this.missileObject.AddComponent<SpriteRenderer>();
        else
            this.spriteRenderer = this.missileObject.GetComponent<SpriteRenderer>();
        this.sprites = Resources.LoadAll<Sprite>(spritesLocation);
        this.spriteRenderer.sprite = this.sprites[currentSprite];
    }

    // Update is called once per frame
    void Update()
    {
        updateStatus();
        if (inPreparation)
        {
            if (updateDirection())
                updateRotation();
            updateSprite();
        }
        if (inPreparation)
        {
            updateDirection();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
        }
    }

    void updateStatus()
    {
        if (Input.GetKeyDown(myPlayer.controls["Missile"]))
        {
            if (ammunition > 0)
            {
                if (inPreparation)
                {
                    inPreparation = false;
                    missileContainer.SetActive(false);
                    Launch();
                }
                else
                {
                    inPreparation = true;
                    missileContainer.SetActive(true);
                }
            }
            else
            {
                Debug.Log(myPlayer.username + ": No ammo.");
            }
        }
    }

    void updateSprite()
    {
        fluctuationTime += Time.deltaTime;
        float fluctuationFrequency = 1f / framesPerSecond;
        if (fluctuationTime > fluctuationFrequency)
        {
            currentSprite++;
            if (currentSprite == this.sprites.Length)
                currentSprite = 0;
            fluctuationTime -= fluctuationFrequency;
            this.spriteRenderer.sprite = this.sprites[currentSprite];
        }
    }

    void updateRotation()
    {
        missileContainer.transform.up = Vector3.Slerp(missileContainer.transform.up, targetPosition, rotationSpeed);
        //this.missileContainer.transform.rotation = Quaternion.Slerp(this.missileContainer.transform.rotation, this.targetRotation, this.rotationSpeed);
    }

    bool updateDirection()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(myPlayer.controls["Shield_Left"]))
            direction.x--;
        if (Input.GetKey(myPlayer.controls["Shield_Right"]))
            direction.x++;
        if (Input.GetKey(myPlayer.controls["Shield_Down"]))
            direction.y--;
        if (Input.GetKey(myPlayer.controls["Shield_Up"]))
            direction.y++;
        if (direction == Vector2.zero)
        {
            Vector3 closest = myPlayer.getClosestPlayer().gameObject.transform.position;
            Vector3 myPosition = myPlayer.gameObject.transform.position;
            targetPosition = closest - myPosition;
        }
        else
        {
            targetPosition = direction;
        }
        //if (direction != Vector2.zero)
        //{
        //    direction.Normalize();
        //    float newAngle = -Vector2.SignedAngle(direction, Vector2.up);
        //    this.targetRotation = Quaternion.Euler(new Vector3(0, 0, newAngle));
        //    return true;
        //}
        return true;
    }

    void Launch()
    {

    }
}
