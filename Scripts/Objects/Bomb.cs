using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool isDetonated;

    private Sprite[] sprites;
    private string sprite_loc;
    private string bomb_location;
    private SpriteRenderer spriteRenderer;
    private int currentSprite;
    private float flunctuationTime;

    public int fps;

    public float explosionRadius;
    public int bombDamage;


    // Start is called before the first frame update
    void Start()
    {
        sprite_loc = "sci-fi-effects/explosion";
        this.sprites = Resources.LoadAll<Sprite>(sprite_loc);
        this.explosionRadius = 3.0f;
        this.bombDamage = 20;
        isDetonated = false;
        fps = 16;

        this.bomb_location = "bomb";
        this.spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Resources.Load(bomb_location, typeof(Sprite)) as Sprite;
        this.gameObject.transform.localScale = new Vector2(0.092023f, 0.07978807f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDetonated)
        {
            updateSprite();
        }
    }

    private void updateSprite()
    {
        Debug.Log("explosion");

        flunctuationTime += Time.deltaTime;
        float fluctuationFrequency = 1f / fps;
        if (flunctuationTime > fluctuationFrequency)
        {
            currentSprite++;
            if (currentSprite == this.sprites.Length)
            {
                isDetonated = false;
                doDamage();
                Destroy(this.gameObject);
                return;
            }
            flunctuationTime -= fluctuationFrequency;
            this.spriteRenderer.sprite = this.sprites[currentSprite];
        }
    }

    // public so it can be called from BombManager
    public void activateBomb()
    {
        Debug.Log("detonating");
        isDetonated = true;
        currentSprite = 0;
        this.gameObject.transform.localScale = new Vector2(2f, 2f);
        this.spriteRenderer.sprite = sprites[currentSprite];
    }

    private void doDamage()
    {
        Vector2 bombPos = this.gameObject.transform.position;
        List<Player> players = GameManager.players;
        foreach (Player p in players)
        {
            Vector2 playerPos = p.gameObject.transform.position;
            if (Vector2.Distance(playerPos, bombPos) < explosionRadius)
            {
                p.healthManager.minusHP(bombDamage);
            }
        }
    }
}
