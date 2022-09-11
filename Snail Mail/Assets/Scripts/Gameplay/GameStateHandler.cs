using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] float dramaticPauseDelay = 3f;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    [SerializeField] GameObject[] objectsToDisable;

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
        StartCoroutine(DramaticWin());
    }

    public void LoseGame()
    {
        StartCoroutine(DramaticLose());
    }

    public void PauseGameSystems()
    {
        Time.timeScale = 0f;
    }

    IEnumerator DramaticWin()
    {
        yield return new WaitForSeconds(dramaticPauseDelay);
        winScreen.SetActive(true);
        PauseGameSystems();
    }
    IEnumerator DramaticLose()
    {
        ManuallyDisableGameSystems();
        FindObjectOfType<CinemachineShake>().ShakeCamera(3f, 1f, dramaticPauseDelay);

        yield return new WaitForSeconds(dramaticPauseDelay);

        loseScreen.SetActive(true);
        PauseGameSystems();
    }
    private void ManuallyDisableGameSystems()
    {
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<SandCastle>().enabled = false;

        FindObjectOfType<ObstacleGeneration>().enabled = false;
        FindObjectOfType<MapScroll>().enabled = false;
        FindObjectOfType<MapGeneration>().enabled = false;

        foreach(GameObject g in objectsToDisable)
        {
            g.SetActive(false);
        }
        FindObjectOfType<AttackSpawner>().enabled = false;
        foreach(Rigidbody2D rb in FindObjectsOfType<Rigidbody2D>())
        {
            rb.freezeRotation = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        foreach(Attack a in FindObjectsOfType<Attack>())
        {
            a.enabled = false;
        }
        foreach(Animator anim in FindObjectsOfType<Animator>())
        {
            anim.enabled = false;
        }
    }
}
