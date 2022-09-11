using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteTrigger : MonoBehaviour
{
    
    public PostProcessVolume volume;
    private Vignette vignette;
    private SnailHide s; 
    private float t;
    
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        s = FindObjectOfType<SnailHide>();
    }

    // Update is called once per frame
    void Update()
    {
        if(s.hiding)
        {
            t += 2 * Time.deltaTime;
            
            vignette.smoothness.value = Mathf.Lerp(0, 1, t);
            
        }
        else{
            t = 0;
            vignette.smoothness.value = 0;
        }
    }
}
