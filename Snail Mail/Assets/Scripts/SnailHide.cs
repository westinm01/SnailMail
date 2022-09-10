using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailHide : MonoBehaviour
{
    [SerializeField] KeyCode hideKey;

    // private vars
    bool hiding = false;

    // cached referenced
    PlayerHealth playerHealth;
    Animator anim;
    PlayerMovement movement;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        anim = GetComponent<Animator>();
        movement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(hideKey) && !hiding)
        {
            hiding = true;
            playerHealth.SetPlayerInvincible(true);
            anim.SetBool("hiding", true);
            //movement.enabled = false;
            movement.LockMovement(true);
        } 
        else if(Input.GetKeyUp(hideKey) && hiding)
        {
            hiding = false;
            playerHealth.SetPlayerInvincible(false);
            anim.SetBool("hiding", false);
            //movement.enabled = true;
            movement.LockMovement(false);
        }
    }
}
