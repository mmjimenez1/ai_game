using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : ManagerClass
{
    public int epPerSecond;
    public float timeElapsed;
    [SerializeField]
    private bool isActive;
    private Quaternion targetRotation;
    public float rotationSpeed;

    private GameObject shieldObject;
    private GameObject shieldContainer;

    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int currentSprite;
    public int framesPerSecond;
    private float fluctuationTime;
    private string spritesLocation;

    // Start is called before the first frame update
    void Start()
    {

        this.shieldContainer = new GameObject("ShieldContainer" + myPlayer.username);
        this.shieldContainer.transform.parent = myPlayer.gameObject.transform;

        //this.shieldObject = new GameObject("Shield " + myPlayer.username);
        this.shieldObject = Instantiate(Resources.Load("Prefabs/ShieldPrefab") as GameObject, Vector3.zero, Quaternion.identity);
        this.shieldObject.name = "Shield " + myPlayer.username;

        this.shieldObject.transform.parent = shieldContainer.transform;
        this.shieldObject.transform.localPosition = new Vector2(0, 0.35f);
        this.shieldObject.transform.localScale = new Vector2(0.45f, 0.35f);

        this.targetRotation = this.shieldContainer.transform.rotation;
        this.rotationSpeed = 0.1f;
        this.epPerSecond = 1;
        this.timeElapsed = 0;

        this.framesPerSecond = 15;
        this.currentSprite = 0;
        this.spritesLocation = "sci-fi-effects/front_shieldB";
        if(this.shieldObject.GetComponent<SpriteRenderer>() == null)
            this.spriteRenderer = this.shieldObject.AddComponent<SpriteRenderer>();
        else
            this.spriteRenderer = this.shieldObject.GetComponent<SpriteRenderer>();
        this.sprites = Resources.LoadAll<Sprite>(spritesLocation);
        this.spriteRenderer.sprite = this.sprites[currentSprite];

        setActiveShield(false);
    }

    // Update is called once per frame
    void Update()
    {
        updateStatus();
        if (isActive)
        {
            if (updateDirection())
                updateRotation();
            updateSprite();
            updatePlayerEnergy();
        }
    }

    void updateStatus()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            setActiveShield(!this.isActive);
        }
    }

    void setActiveShield(bool active)
    {
        this.isActive = active;
        this.shieldContainer.SetActive(this.isActive);
        if(this.isActive)
            timeElapsed++;//add 1 second so that the player will lose 2 ep per activation
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

    void updatePlayerEnergy()
    {
        if (!myPlayer.energyManager.isEnough(epPerSecond))
        {
            print("Not enough energy1. Deactivating.");
            setActiveShield(false);
            return;
        }
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1)
        {
            timeElapsed--;
            if (myPlayer.energyManager.minusEP(epPerSecond) < epPerSecond)
            {
                print("Not enough energy2. Deactivating.");
                setActiveShield(false);
            }
        }
    }

    void updateRotation()
    {
        this.shieldContainer.transform.rotation = Quaternion.Slerp(this.shieldObject.transform.rotation, this.targetRotation, this.rotationSpeed);
    }

    bool updateDirection()
    {
        Vector2 direction = Vector2.zero;
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
        if (direction != Vector2.zero)
        {
            direction.Normalize();
            //float currentZAngle = shieldObject.transform.eulerAngles.z;
            float newAngle = -Vector2.SignedAngle(direction, Vector2.up);
            //float deltaAngle = newAngle - currentZAngle;
            //this.shieldObject.transform.Rotate(Vector3.forward, deltaAngle);
            this.targetRotation = Quaternion.Euler(new Vector3(0, 0, newAngle));
            return true;
        }
        return false;
    }
}
