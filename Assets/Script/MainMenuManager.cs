using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //public string targetScene;
    // Start is called before the first frame update
    //public GameObject creditPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtn(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
