using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //public string targetScene;
    // Start is called before the first frame update
    //public GameObject creditPanel;
    public Text highScoreText;
    void Start()
    {
        Time.timeScale = 1;
        ShowHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtn(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowHighScore(){
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
    }
}
