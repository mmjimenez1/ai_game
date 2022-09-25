using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<Player>();
        this.players.Add(new Player("Player1"));
        this.players.Add(new Player("Player2"));
        players.ForEach(p => Debug.Log(p.username));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
