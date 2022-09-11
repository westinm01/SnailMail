using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCastle : MonoBehaviour
{
    public float timeToWin;
    public float currentTime;
    Rigidbody2D rb;
    public GameStateHandler gameStateHandler;
    private ObstacleGeneration og;

    void Start()
    {
        currentTime = 0f;
        rb = GetComponent<Rigidbody2D>();
        gameStateHandler = FindObjectOfType<GameStateHandler>();
        og = FindObjectOfType<ObstacleGeneration>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timeToWin)
        {
            og.enabled = false;   
            rb.velocity = new Vector2(-2,0);
        }
    }
    
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            gameStateHandler.WinGame();
            
        }
    }
}
