using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public float timer;
    public float startOffset;
    
    public GameObject backgroundObject;
    private float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        timePassed = startOffset;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= timer)
        {   GameObject newMap = Instantiate(backgroundObject, this.transform, false);
            newMap.transform.position = new Vector3(19.0f, 0, 10);
            timePassed = 0;
            Destroy(newMap, 25f);
        }
    }
}
