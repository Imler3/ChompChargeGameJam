using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    // Load Index on click of Start Button
    public int sceneIndex;
    public Pause_Menu pauseMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        pauseMenu.Paused = false;
        SceneManager.LoadScene(sceneIndex);
    }
}
