using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] float dramaticPauseDelay = 3f;

    [SerializeField] GameObject winScreen;
    [SerializeField] AudioClip winSFX;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Sprite koSprite;
    [SerializeField] GameObject loseVFX;
    [SerializeField] AudioClip loseSFX;
    [SerializeField] AudioClip snatchSFX;
    [SerializeField] GameObject fadeToBlack;
    [SerializeField] GameObject fadeToRed;

    [SerializeField] GameObject[] objectsToDisable;
    bool winning = false;
    bool losing = false;
    GameObject player;

    private void Start()
    {
        Singleton[] singletons = FindObjectsOfType<Singleton>();
        foreach (Singleton s in singletons)
        {
            Destroy(s.gameObject);
        }

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        fadeToBlack.SetActive(false);
        fadeToRed.SetActive(false);
        player = FindObjectOfType<PlayerMovement>().gameObject;
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
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position);
        fadeToBlack.SetActive(true);

        yield return new WaitForSeconds(dramaticPauseDelay);

        winScreen.SetActive(true);
        PauseGameSystems();
    }
    IEnumerator DramaticLose()
    {
        losing = true;
        player.GetComponent<Animator>().SetBool("ko", true);
        player.GetComponent<SpriteRenderer>().sprite = koSprite;
        ManuallyDisableGameSystems();
        FindObjectOfType<CinemachineShake>().ShakeCamera(3f, 1f, dramaticPauseDelay);
        Instantiate(loseVFX, player.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(loseSFX, Camera.main.transform.position);
        fadeToRed.SetActive(true);

        yield return new WaitForSeconds(dramaticPauseDelay);

        loseScreen.SetActive(true);
        AudioSource.PlayClipAtPoint(snatchSFX, Camera.main.transform.position);
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
