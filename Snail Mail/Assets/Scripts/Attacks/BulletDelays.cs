using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelays : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] GameObject[] bulletsToDelay;

    float elapsedTime = 0f;
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in bulletsToDelay)
        {
            g.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= delayTime && currentIndex < bulletsToDelay.Length)
        {
            elapsedTime = 0f;
            bulletsToDelay[currentIndex].SetActive(true);
            Debug.Log("set " + currentIndex + " true");
            currentIndex++;
        }
    }
}
