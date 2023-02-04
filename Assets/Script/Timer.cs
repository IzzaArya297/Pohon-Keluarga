using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;
    public GameObject pausePanel;

    private bool stopTimer;
    // Start is called before the first frame update
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
        
    }

    IEnumerator timer(){
            float time = gameTime - Time.time;
            while(time > 0){
            time = gameTime - Time.time;

            int minutes = Mathf.FloorToInt(time/60);
            int seconds = Mathf.FloorToInt(time - minutes * 60);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if(time <= 0){
                stopTimer = true;

            }

            if(stopTimer == false){
                yield return new WaitForEndOfFrame();
                timerText.text = textTime;
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
