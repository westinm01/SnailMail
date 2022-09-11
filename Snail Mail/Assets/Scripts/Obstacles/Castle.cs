using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float slowModifier = .25f;
    public float duration = 3f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<PlayerMovement>().SlowDown(slowModifier, duration);
            GetComponent<AudioSource>().Play();
        }
    }
}
