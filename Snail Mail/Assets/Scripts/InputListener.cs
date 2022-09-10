using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputListener : MonoBehaviour
{
    [SerializeField] UnityEvent myEvent;
    [SerializeField] KeyCode desiredInput;

    private void Update()
    {
        if (Input.GetKeyDown(desiredInput))
        {
            myEvent.Invoke();
        }
    }
}
