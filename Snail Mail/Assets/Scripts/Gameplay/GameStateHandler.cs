using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] float dramaticPauseDelay = 3f;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject fadeToBlack;

    [SerializeField] GameObject[] objectsToDisable;
    bool winning = false;
    bool losing = false;

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
        fadeToBlack.SetActive(false);
    }

    public void WinGame()
    {
        if(!winning && !losing)
        {
            StartCoroutine(DramaticWin());
        }
    }

    public void LoseGame()
    {
        if(!winning && !losing)
        {
            StartCoroutine(DramaticLose());
        }
    }

    public void PauseGameSystems()
    {
        Time.timeScale = 0f;
    }

    IEnumerator DramaticWin()
    {
        winning = true;
        ManuallyDisableGameSystems();
        FindObjectOfType<CinemachineShake>().ShakeCamera(3f, 1f, dramaticPauseDelay);
        fadeToBlack.SetActive(true);

        yield return new WaitForSeconds(dramaticPauseDelay);

        winScreen.SetActive(true);
        PauseGameSystems();
    }
    IEnumerator DramaticLose()
    {
        losing = true;
        ManuallyDisableGameSystems();
        FindObjectOfType<CinemachineShake>().ShakeCamera(3f, 1f, dramaticPauseDelay);

        yield return new WaitForSeconds(dramaticPauseDelay);

        loseScreen.SetActive(true);
        PauseGameSystems();
    }
    private void ManuallyDisableGameSystems()
    {
        FindObjectOfType<AttackSpawner>().enabled = false;
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<SandCastle>().enabled = false;
        FindObjectOfType<ObstacleGeneration>().enabled = false;
        FindObjectOfType<MapScroll>().enabled = false;
        FindObjectOfType<MapGeneration>().enabled = false;

        foreach(BulletDelays b in FindObjectsOfType<BulletDelays>())
        {
            b.enabled = false;
        }
        foreach(AutoDestroy ad in FindObjectsOfType<AutoDestroy>())
        {
            ad.enabled = false;
        }
        foreach(GameObject g in objectsToDisable)
        {
            g.SetActive(false);
        }
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
