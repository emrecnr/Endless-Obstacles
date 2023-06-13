using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    private string gameSceneName = "Prototype 3";
    private string mainMenuName = "MainMenu";
    public SceneFader fader;
    public void Play()
    {
        fader.FadeTo(gameSceneName);
        //SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Quit Game !");
        Application.Quit();
    }
    
    public void Retry()
    {
        fader.FadeTo(SceneManager.GetActiveScene().name);
        
    }

    
}
