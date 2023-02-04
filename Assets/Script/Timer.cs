using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer TimerInstance { get; private set; }
    public Slider timerSlider;
    public float gameTime;
    public GameObject pausePanel;
    public bool isPause;

    private bool stopTimer;
    // Start is called before the first frame update
    private void Awake() 
    { 
        // If there is an TimerInstance, and it's not me, delete myself.
    
        if (TimerInstance != null && TimerInstance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            TimerInstance = this; 
        } 
    }
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;

        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPause){
            if(Input.GetKeyDown(KeyCode.Escape)){
                PauseGame();
                isPause = true;
            }
        }else{
            if(Input.GetKeyDown(KeyCode.Escape)){
                ResumeGame();
                isPause = false;
            }
        }
        
    }

    IEnumerator timer(){
            float time = gameTime - Time.time;
            while(time > 0){
            time = gameTime - Time.time;

            int minutes = Mathf.FloorToInt(time/60);
            int seconds = Mathf.FloorToInt(time - minutes * 60);

            //string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if(time <= 0){
                stopTimer = true;
                GameManager.Instance.GameOver();
            }

            if(stopTimer == false){
                yield return new WaitForEndOfFrame();
                timerSlider.value = time;
            }
        }
    }

    public void PauseGame(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
