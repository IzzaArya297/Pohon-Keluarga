using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] targetObject;
    [SerializeField]
    private float duration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(targetObject[0].position.x, targetObject[0].position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera(){
        
        StartCoroutine(LerpPosition(targetObject[1].position, duration));
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        Vector3 target = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
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
