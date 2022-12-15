using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserManager : ManagerClass
{
    public bool isActive { get; protected set; }
    KeyCode laserKey;
    public int dmgPerSecond { get; protected set; }
    public int epPerSecond { get; protected set; }
    private float energyConsumed;
    [SerializeField]

    private GameObject laserObject;
    private GameObject laserContainer;
    private Player target;
    private LaserCollision laserCollision;

    // sprite related variables
    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int currentSprite;
    public int framesPerSecond;
    private float fluctuationTime;
    private string spritesLocation;
    public bool aiLaserActive;

    private float initialHalfLength;
    // username -> health, energy
    Dictionary<string, Vector2> damageDealt;

    // Start is called before the first frame update
    void Start()
    {
        laserKey = myPlayer.controls["Laser"];

        dmgPerSecond = 24;
        epPerSecond = 16;
        energyConsumed = 0f;

        laserContainer = new GameObject("LaserContainer");
        laserContainer.transform.parent = myPlayer.gameObject.transform;
        laserContainer.transform.localPosition = new Vector2(0f, 0f);
        
        laserObject = new GameObject("Laser " + myPlayer.username);
        laserObject.transform.parent = laserContainer.transform;
        laserObject.transform.rotation = Quaternion.identity;
        laserObject.transform.localScale = new Vector2(8f, 1f);
        spriteRenderer = laserObject.AddComponent<SpriteRenderer>();

        framesPerSecond = 15;
        currentSprite = 0;
        spritesLocation = "sci-fi-effects/pulsating_beam";
        sprites = Resources.LoadAll<Sprite>(spritesLocation);
        spriteRenderer.sprite = sprites[currentSprite];

        initialHalfLength = 1.15f;
        laserObject.transform.localPosition = new Vector2(0f, spriteRenderer.bounds.extents.y);

        BoxCollider2D collider = laserObject.AddComponent<BoxCollider2D>();
        collider.offset = new Vector2(0.02f, 0f);
        collider.size = new Vector2(0.02f, 2.3f);
        collider.isTrigger = true;

        Rigidbody2D rigid = laserObject.AddComponent<Rigidbody2D>();
        rigid.isKinematic = true;
        //rigid.useFullKinematicContacts = true;

        // username -> health, energy
        damageDealt = new Dictionary<string, Vector2>();
        foreach (Player p in Player.getEnemies(myPlayer))
        {
            this.damageDealt.Add(p.username, Vector2.zero);
        }

        laserCollision = laserObject.AddComponent<LaserCollision>();
        laserCollision.setUp(myPlayer);

        setActiveLaser(false);
    }

    // Update is called once per frame
    void Update()
    {
        updateStatus();
        if (isActive)
        {
            // find the closest enemy
            target = myPlayer.getClosestPlayer();
            Vector2 myPosition = myPlayer.gameObject.transform.position;
            Vector2 targetPosition = target.gameObject.transform.position;
            // change the scale of the sprite so that it spans from the player to the enemy
            updateLength(myPosition, targetPosition);
            // rotate the sprite so that it points towards the enemy
            updateRotation(myPosition, targetPosition);
            updateSprite();
            updateEnemyDamage();
            updatePlayerEnergy();
        }
    }

    void updateStatus()
    {
        if (Input.GetKey(laserKey) || aiLaserActive)
        {
            if (!isActive)
                setActiveLaser(true);
        }
        else if(isActive)
            setActiveLaser(false);
    }

    public void setActiveLaser(bool active)
    {
        // needs at least 1 of energy to be active for an instant
        if (active && myPlayer.energyManager.isEnough(1))
        {
            myPlayer.missileManager.setActiveMissile(false);
            this.isActive = true;
            this.laserContainer.SetActive(true);
            // no energy lost per activation (can be spammed)
            // myPlayer.energyManager.minusEP(1);
        }
        else
        {
            this.isActive = false;
            this.laserContainer.SetActive(false);
        }
    }

    void updatePlayerEnergy()
    {
        energyConsumed += epPerSecond * Time.deltaTime;
        if (energyConsumed >= 1f)
        {
            energyConsumed--;
            myPlayer.energyManager.minusEP(1);
            if (!myPlayer.energyManager.isEnough(1))
            {
                print("Not enough energy. Deactivating Laser.");
                setActiveLaser(false);
            }
        }
    }

    void updateEnemyDamage()
    {
        Dictionary<string, Player> pDict = GameManager.playerDictionary;

        // using ToList() creates a copy, so damageDealt can be modified without errors jumping
        foreach (string enemyUsername in damageDealt.Keys.ToList())
        {
            Player enemy = pDict[enemyUsername];
            Vector2 damage = damageDealt[enemyUsername];
            if (laserCollision.shieldHit[enemyUsername])
            {
                // enemy only loses half of damage as energy if shielded
                damage.y += dmgPerSecond * 0.5f * Time.deltaTime;
                if (damage.y >= 1f)
                {
                    damage.y--;
                    enemy.energyManager.minusEP(1);
                }
                damageDealt[enemyUsername] = damage;
            }
            else if (laserCollision.enemyHit[enemyUsername])
            {
                // enemy loses normal damage as health if not shielded
                damage.x += dmgPerSecond * Time.deltaTime;
                if (damage.x >= 1f)
                {
                    damage.x--;
                    enemy.healthManager.minusHP(1);
                }
                damageDealt[enemyUsername] = damage;
            }
        }
    }

    void updateRotation(Vector3 myPosition, Vector3 targetPosition)
    {
        laserContainer.transform.up = targetPosition - myPosition;
    }

    void updateLength(Vector3 myPosition, Vector3 targetPosition)
    {
        float distance = Vector2.Distance(myPosition, targetPosition);
        float newLength = distance * 0.5f / initialHalfLength;// distance / 2 / initialSize.Y
        Vector2 newScale = laserObject.transform.localScale;
        newScale.y = newLength;
        laserObject.transform.localScale = newScale;

        float newPositionY = initialHalfLength * newScale.y;
        laserObject.transform.localPosition = new Vector2(-0.1f, newPositionY);
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

    private class LaserCollision : MonoBehaviour
    {
        Player myPlayer;

        public Dictionary<string, bool> enemyHit;
        public Dictionary<string, bool> shieldHit;
        public bool triggered;

        public void setUp(Player myPlayer)
        {
            this.myPlayer = myPlayer;
            this.enemyHit = new Dictionary<string, bool>();
            this.shieldHit = new Dictionary<string, bool>();
            foreach (Player p in Player.getEnemies(myPlayer))
            {
                this.enemyHit.Add(p.username, false);
                this.shieldHit.Add(p.username, false);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            string tag = collision.gameObject.tag;
            // check for collision with player
            if (tag == "Player")
            {
                Player enemy = collision.gameObject.GetComponent<PlayerManager>().GetPlayer();
                if (myPlayer.username != enemy.username)
                {
                    this.enemyHit[enemy.username] = true;
                }
            }
            // check for collision with shield
            else if (tag == "Shield")
            {
                Player enemy = collision.gameObject.GetComponentInParent<PlayerManager>().GetPlayer();
                this.shieldHit[enemy.username] = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            string tag = collision.gameObject.tag;
            // check for collision exit with player
            if (tag == "Player")
            {
                Player enemy = collision.gameObject.GetComponent<PlayerManager>().GetPlayer();
                if (myPlayer.username != enemy.username)
                {
                    this.enemyHit[enemy.username] = false;
                }
            }
            // check for collision exit with shield
            else if (tag == "Shield")
            {
                Player enemy = collision.gameObject.GetComponentInParent<PlayerManager>().GetPlayer();
                this.shieldHit[enemy.username] = false;
            }
        }
    }
}

