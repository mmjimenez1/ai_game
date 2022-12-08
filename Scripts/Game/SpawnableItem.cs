using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class SpawnableItem : ScriptableObject
{
    public string itemName;
    public float waitTime;
    public float duration;
    public int pickUpAmount;

    public Vector2 bounds;

    public Sprite containerSprite;
    public Sprite itemSprite;
    public Color containerColor;

    public GameObject container { get; private set; }
    protected GameObject item { get; private set; }
    public Vector2 spawnPosition { get; private set; }

    public bool isActive { get; private set; }
    public float timeElapsed { get; private set; }

    public abstract void pickUp(Player player);

    public void setUp()
    {
        container = new GameObject(itemName);
        CircleCollider2D collider = container.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
        collider.radius = 0.75f;
        Rigidbody2D rigid = container.AddComponent<Rigidbody2D>();
        rigid.isKinematic = true;
        ItemCollision itemCollider = container.AddComponent<ItemCollision>();
        itemCollider.setUp(this);

        item = new GameObject("Item");
        item.transform.parent = container.transform;
        setUpItemScale();
        SpriteRenderer containerSpRend = container.AddComponent<SpriteRenderer>();
        SpriteRenderer itemSpRend = item.AddComponent<SpriteRenderer>();
        containerSpRend.sprite = containerSprite;
        itemSpRend.sprite = itemSprite;
        containerSpRend.sortingOrder = 3;
        itemSpRend.sortingOrder = 5;
        containerSpRend.color = containerColor;

        timeElapsed = waitTime;
        container.SetActive(false);

        bounds = new Vector2(9f, 4.5f);
    }

    protected abstract void setUpItemScale();

    public void updateStatus()
    {
        timeElapsed -= Time.deltaTime;
        if (timeElapsed < 0)
        {
            if(isActive)
                despawn();
            else
                spawn();
        }
    }

    public void spawn()
    {
        float x = Random.Range(-bounds.x, bounds.x);
        float y = Random.Range(-bounds.y, bounds.y);
        spawnPosition = new Vector2(x, y);
        isActive = true;
        timeElapsed = duration;
        container.transform.position = spawnPosition;
        container.SetActive(true);
    }

    public void despawn()
    {
        isActive = false;
        timeElapsed = waitTime;
        container.SetActive(false);
    }

    private class ItemCollision : MonoBehaviour
    {
        SpawnableItem item;

        public void setUp(SpawnableItem item)
        {
            this.item = item;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            string tag = collision.gameObject.tag;
            // check for collision with player
            if (tag == "Player")
            {
                Player player = collision.gameObject.GetComponent<PlayerManager>().GetPlayer();
                item.pickUp(player);
                item.despawn();
            }
        }
    }
}
