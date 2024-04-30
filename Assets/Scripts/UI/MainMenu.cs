using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;
    public GameObject paintingsWindow;
    public void NewGame(){
        SceneManager.LoadScene(levelToLoad);
    }
    public void Settings(){
        settingsWindow.SetActive(true);
    }
    public void CloseSettingsWindow(){
        settingsWindow.SetActive(false);
    }
    public void PaintingsWindow()
    {
        paintingsWindow.SetActive(true);
    }
    public void ClosePaintingsWindow()
    {
        paintingsWindow.SetActive(false);
    }
    public void Quit(){
        Application.Quit();
    }
}
