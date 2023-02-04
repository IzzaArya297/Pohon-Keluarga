using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    
    public Vector3 offsetTargetPosition;
    public Vector3 offsetDown;
    public float duration;
    public bool moveDown = false;
    public BoxCollider2D collide;
    public bool isPartner = true;

    private void Awake() {
        collide = GetComponent<BoxCollider2D>();
    }

    public void StartMove(){
        if(GameManager.Instance.isClick == false && !isPartner){
            
            StartCoroutine(LerpPosition(offsetTargetPosition, duration));
            GameManager.Instance.isClick = true;
            CharSpawnTemp.charSpawn.mainCard = GetComponent<CharCard>();
            CharSpawnTemp.charSpawn.mainCard.sortingFix(31);
            CharSpawnTemp.charSpawn.currentCharacter = CharSpawnTemp.charSpawn.mainCard.charTraits;
        }
    }

    public void MoveDown(){
        if(moveDown == true){
            StartCoroutine(CharSpawnTemp.charSpawn.NewLevel(gameObject.transform.position + offsetDown, duration+1));
            StartCoroutine(LerpPosition(gameObject.transform.position + offsetDown, duration));
            moveDown = false;
            CameraController.CameraInstance.MoveCamera(gameObject.transform.position + offsetDown);
            collide.enabled = false;
            GameManager.Instance.isClick = false;
        }
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
        moveDown = true;
    }
}
