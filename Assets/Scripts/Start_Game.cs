using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    // Load Index on click of Start Button
    public int sceneIndex;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
