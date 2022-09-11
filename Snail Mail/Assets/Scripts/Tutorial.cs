using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();
    private int index = 0;

    public SceneLoader sc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            panels[index].SetActive(false);
            index++;
            if(index >= panels.Count)
            {
                sc.LoadNextScene();
            }
            else
            {
                panels[index].SetActive(true);
            }
        }
    }
}
