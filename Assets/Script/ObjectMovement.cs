using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    
    public Vector3 offsetTargetPosition;
    public Vector3 offsetDown;
    public float duration;
    public float duration_score_show;
    public bool moveDown = false;
    public BoxCollider2D collide;
    public bool isPartner = true;
    public int a_parameter;
    public float penaltyTime = 5f;

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

            if(CharSpawnTemp.charSpawn.mainCard.parentTraits == 5){
                GameManager.Instance.score += (int)(1 * a_parameter);
                StartCoroutine(GameManager.Instance.showImage(0, duration_score_show + duration));
                Music.Instance.PlayAnswer(5);
                Debug.Log("5T");
                Timer.TimerInstance.sum = Timer.TimerInstance.sum - 5 < 0 ? 0 : Timer.TimerInstance.sum - 5;
                Music.Instance.timer = Music.Instance.timer - 5 < 0? 0 : Music.Instance.timer - 5;
            }else if(CharSpawnTemp.charSpawn.mainCard.parentTraits == 4){
                GameManager.Instance.score += (int)(0.5 * a_parameter);
                StartCoroutine(GameManager.Instance.showImage(1, duration_score_show + duration));
                Music.Instance.PlayAnswer(4);
                Debug.Log("4T");
            }else if(CharSpawnTemp.charSpawn.mainCard.parentTraits == 3){
                GameManager.Instance.score += (int)(0.25 * a_parameter);
                StartCoroutine(GameManager.Instance.showImage(2, duration_score_show + duration));
                Music.Instance.PlayAnswer(3);
                Debug.Log("3T");
            }else{
                Debug.Log("SALAH");
                Music.Instance.PlayAnswer(2);
                StartCoroutine(GameManager.Instance.showImage(3, duration_score_show + duration));
                Timer.TimerInstance.sum += penaltyTime;
                Music.Instance.timer += penaltyTime;
            }
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
        if(GameManager.Instance.isClick && moveDown)
        {
            yield return new WaitForSeconds(duration_score_show);
            MoveDown();
        }
    }
}
