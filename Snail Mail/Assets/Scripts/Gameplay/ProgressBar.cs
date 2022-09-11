using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public SandCastle sandCastle;
    Vector3 scaleVals;
    private float timer;
    private float currentTime;
    private float currentXScale;
    private float timeRatio;
    private bool completed;
    // Start is called before the first frame update
    void Start()
    {
        timer = sandCastle.timeToWin;
        currentTime = sandCastle.currentTime;
        currentXScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(!completed)
        {
            scaleVals = transform.localScale;
            currentTime = sandCastle.currentTime;
            timeRatio = currentTime / timer;
        }
        if(currentTime >= timer)
        {
            currentTime = timer;
            completed = true;
        }
        transform.localScale = new Vector3(timeRatio * currentXScale, transform.localScale.y, transform.localScale.z);
        
    }
}
