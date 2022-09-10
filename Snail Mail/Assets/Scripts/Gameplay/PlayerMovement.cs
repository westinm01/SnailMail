using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    private bool isSlowed = false;
    private float baseRunSpeed;
    private float slowDuration;
    private float slowTimePassed;
    //private Animator anim;
    
    public float leftBound = -8;
    public float rightBound = 8;
    public float topBound = 4;
    public float bottomBound = -4;

    private MapScroll scroller;

    bool movementLocked;

    void Start ()
    {
        baseRunSpeed = runSpeed;
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        scroller = FindObjectOfType<MapScroll>();
    
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (isSlowed)
        {
            slowTimePassed += Time.deltaTime;
            if (slowTimePassed >= slowDuration)
            {
                runSpeed = baseRunSpeed;
                isSlowed = false;
            }
        }
    }

    void FixedUpdate()
    {
        /*
        if(horizontal != 0)
        {
            GetComponent<SpriteRenderer>().flipX = horizontal < 0;
            anim.SetBool("isWalking", true);
        }
        else{
            anim.SetBool("isWalking", false);
        }
        */
        //Debug.Log(horizontal + ", " + vertical);
        if (this.transform.position.x < rightBound && this.transform.position.x > leftBound && this.transform.position.y < topBound && this.transform.position.y > bottomBound)
        {
            Move();
        }
        //corner cases
        else if (this.transform.position.x >= rightBound && horizontal <= 0 && this.transform.position.y >= topBound && vertical <= 0)
        {
            Move();
        }
        else if (this.transform.position.x >= rightBound && horizontal <= 0 && this.transform.position.y <= bottomBound && vertical >= 0)
        {
            Move();
        }
        else if (this.transform.position.x <= leftBound && horizontal >= 0 && this.transform.position.y >= topBound && vertical <= 0)
        {
            Move();
        }
        else if (this.transform.position.x <= leftBound && horizontal >= 0 && this.transform.position.y <= bottomBound && vertical >= 0)
        {
            
            Move();
        }
        //single plane cases
        else if (this.transform.position.x >= rightBound && horizontal <= 0 && InYBounds()){
            Move();
        }
        else if (this.transform.position.x <= leftBound && horizontal >= 0 && InYBounds())
        {
            Move();
        }
        else if (this.transform.position.y >= topBound && vertical <= 0 && InXBounds())
        {
            Move();
        }
        else if (this.transform.position.y <= bottomBound && vertical >= 0 && InXBounds())
        {
            Move();
        }
        else{
            body.velocity = new Vector2(-1 * scroller.scrollSpeed, 0);
        }
        

    }


    void Move(){
        if (movementLocked)
        {
            body.velocity = new Vector2(-1 * scroller.scrollSpeed, 0);
            return;
        }
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement and slow it
        {
            body.velocity = new Vector2(horizontal * runSpeed * 0.7f, vertical * runSpeed * 0.7f); 
        } 
        //else if not moving at all
        else if(horizontal == 0 && vertical == 0){
            body.velocity = new Vector2(-1 * scroller.scrollSpeed, 0);
        }
        else
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }

    public void SlowDown(float modifier, float duration)
    {
        runSpeed *= modifier;
        slowDuration = duration;
        slowTimePassed = 0;
        isSlowed = true;
    }


    bool InXBounds()
    {
        return this.transform.position.x < rightBound && this.transform.position.y > leftBound;
    }

    bool InYBounds()
    {
        return this.transform.position.y < topBound && this.transform.position.y > bottomBound;
    }

    public void LockMovement(bool value)
    {
        movementLocked = value;
    }
    
}
