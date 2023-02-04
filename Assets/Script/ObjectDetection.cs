using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetection : MonoBehaviour
{
    public UnityEvent theEvent;
    private void OnMouseDown()
    {
        theEvent.Invoke();
        Debug.Log("Mouse Click Detected");
    }
}
