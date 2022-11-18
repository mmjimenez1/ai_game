using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserManager : ManagerClass
{
    KeyCode laserKey;
    public int epPerSecond;
    public float timeElapsed;
    [SerializeField]
    private bool isActive;

    private GameObject laserObject;
    private GameObject laserContainer;

    // sprite related variables
    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int currentSprite;
    public int framesPerSecond;
    private float fluctuationTime;
    private string spritesLocation;

    private float scaleDenominator;

    // Start is called before the first frame update
    void Start()
    {
        laserKey = myPlayer.controls["Laser"];

        epPerSecond = 16;
        timeElapsed = 0;

        laserContainer = new GameObject("LaserContainer");
        laserContainer.transform.parent = myPlayer.gameObject.transform;
        
        laserObject = new GameObject("Laser " + myPlayer.username);
        laserObject.transform.parent = laserContainer.transform;
        laserObject.transform.rotation = Quaternion.identity;
        laserObject.transform.localScale = new Vector2(4f, 1f);
        spriteRenderer = laserObject.AddComponent<SpriteRenderer>();


        framesPerSecond = 15;
        currentSprite = 0;
        spritesLocation = "sci-fi-effects/pulsating_beam";
        sprites = Resources.LoadAll<Sprite>(spritesLocation);
        spriteRenderer.sprite = sprites[currentSprite];
        scaleDenominator = 0.5f / (spriteRenderer.bounds.extents.y - 0.1f); 
        laserObject.transform.localPosition = new Vector2(0f, spriteRenderer.bounds.extents.y);

        setActiveLaser(false);
    }

    // Update is called once per frame
    void Update()
    {
        updateStatus();
        if (isActive)
        {
            updateSprite();
            // find the closest enemy
            // rotate the sprite so that it points towards the enemy
            // change the scale of the sprite so that it spans from the player to the enemy
            // enable sprite
            updatePlayerEnergy();
        }
    }
    void updateStatus()
    {
        if (Input.GetKeyDown(laserKey))
        {
            setActiveLaser(true);
        }
        if (Input.GetKeyUp(laserKey))
        {
            setActiveLaser(false);
        }
    }

    public void setActiveLaser(bool active)
    {
        // needs energy to at least be active for 1 second
        if (active && myPlayer.energyManager.isEnough(epPerSecond * 2))
        {
            myPlayer.missileManager.setActiveMissile(false);
            this.isActive = true;
            this.laserContainer.SetActive(true);
            myPlayer.energyManager.minusEP(epPerSecond);
        }
        else
        {
            this.isActive = false;
            this.laserContainer.SetActive(false);
        }
    }

    void updatePlayerEnergy()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1f)
        {
            timeElapsed--;
            myPlayer.energyManager.minusEP(epPerSecond);
            if (!myPlayer.energyManager.isEnough(epPerSecond))
            {
                print("Not enough energy. Deactivating Laser.");
                setActiveLaser(false);
            }
        }
    }

    void updateRotation(Vector3 myPosition, Vector3 targetPosition)
    {
        laserContainer.transform.up = targetPosition - myPosition;
        print(myPlayer.username + " "  + targetPosition);
    }

    void updateLength(Vector3 myPosition, Vector3 targetPosition)
    {
        float distance = Vector2.Distance(myPosition, targetPosition);
        float newLength = distance * scaleDenominator;// distance / 2 / initialSize.Y
        Vector2 newScale = laserObject.transform.localScale;
        newScale.y = newLength;
        laserObject.transform.localScale = newScale;
        laserObject.transform.localPosition = new Vector2(0f, newLength);
    }

    void updateSprite()
    {
        Player enemy = myPlayer.getClosestPlayer();
        Vector2 myPosition = myPlayer.gameObject.transform.position;
        Vector2 targetPosition = enemy.gameObject.transform.position;
        updateLength(myPosition, targetPosition);
        updateRotation(myPosition, targetPosition);

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
}
