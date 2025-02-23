using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Camera;
    public AudioManager manager;
    public bool Paused;


    

    void Start()
    {
        manager = GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown ("escape"))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                Canvas.gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                manager.StartStopSong(true);
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                Canvas.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                manager.StartStopSong(false);
                Paused = true;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
       Canvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        manager.StartStopSong(true);
        Paused = false;
    }
    public void Quit()
    {

        Application.Quit();
    }
}
