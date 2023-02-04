using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController CameraInstance { get; private set; }
    public Transform[] targetObject;
    [SerializeField]
    private float duration = 2f;
    public bool move = false;
    private void Awake() 
    { 
        // If there is an CameraInstance, and it's not me, delete myself.
    
        if (CameraInstance != null && CameraInstance != this) 
        { 
           Destroy(this); 
        } 
        else 
        { 
            CameraInstance = this; 
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(targetObject[0].position.x + 6, targetObject[0].position.y - 2, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera(Vector3 targetPosition){
        
        StartCoroutine(LerpPosition(targetPosition, duration));
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        Vector3 target = new Vector3(targetPosition.x + 6, targetPosition.y - 2, transform.position.z);
        float time = 0;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
    }
}
