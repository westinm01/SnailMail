using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Sprite fullHP;
    [SerializeField] Sprite emptyHP;

    [SerializeField] GameObject[] healthIndicators;
    [SerializeField] float invincibleTime = 3f;
    int currentHealth = 3;
    bool invincible = false;

    public void TakeDamage()
    {
        if (invincible)
        {
            FindObjectOfType<CinemachineShake>().ShakeCamera(1f, .25f, .75f);
            return;
        }

        // take damage
        currentHealth--;
        FindObjectOfType<CinemachineShake>().ShakeCamera(2.5f, .25f, .75f);

        GetComponent<AudioSource>().Play();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            FindObjectOfType<GameStateHandler>().LoseGame();
        }
        UpdateIndicators();
        StartCoroutine(InvincibleTime());
    }

    private void UpdateIndicators()
    {
        foreach (GameObject g in healthIndicators)
        {
            g.GetComponent<Image>().sprite = emptyHP;
        }
        for (int i = 0; i < currentHealth; i++)
        {
            healthIndicators[i].SetActive(true);
            healthIndicators[i].GetComponent<Image>().sprite = fullHP;
        }
    }
    
    public void SetPlayerInvincible(bool value)
    {
        invincible = value;
    }

    IEnumerator InvincibleTime()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }
}
