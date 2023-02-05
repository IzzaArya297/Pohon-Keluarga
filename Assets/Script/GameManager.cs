using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isClick;
    public bool isMoving;
    public int score;
    public Text scoreText;
    public Text showScoreText;
    public GameObject gameOverPanel;

    public GameObject[] scoreImage;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void Start() {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update() {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        showScoreText.text = scoreText.text;
        if(score > PlayerPrefs.GetInt("highScore")){
            PlayerPrefs.SetInt("highScore", score);
        }
        
    }

    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int index){
        SceneManager.LoadScene(index);
    }

    public IEnumerator showImage(int score, float duration)
    {
        scoreImage[score].SetActive(true);
        yield return new WaitForSeconds(duration);
        scoreImage[score].SetActive(false);
    }
}
