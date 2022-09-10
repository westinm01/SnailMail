using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    private void Awake()
    {
        Singleton[] singletons = FindObjectsOfType<Singleton>();
        foreach(Singleton s in singletons)
        {
            Destroy(s);
        }
    }

    private void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        PauseGameSystems();
    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
        PauseGameSystems();
    }

    public void PauseGameSystems()
    {
        Time.timeScale = 0f;
        FindObjectOfType<PlayerMovement>().enabled = false;
    }
}
