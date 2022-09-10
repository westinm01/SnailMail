using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<PlayerHealth>().TakeDamage();
    }
}
