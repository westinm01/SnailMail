using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject[] healthIndicators;
    int currentHealth = 3;
    bool invincible = false;

    public void TakeDamage()
    {
        if (invincible)
        {
            return;
        }

        // take damage
        currentHealth--;
        GetComponent<AudioSource>().Play();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            FindObjectOfType<GameStateHandler>().LoseGame();
        }
        UpdateIndicators();
    }

    private void UpdateIndicators()
    {
        foreach (GameObject g in healthIndicators)
        {
            g.SetActive(false);
        }
        for (int i = 0; i < currentHealth; i++)
        {
            healthIndicators[i].SetActive(true);
        }
    }
    
    public void SetPlayerInvincible(bool value)
    {
        invincible = value;
    }
}
