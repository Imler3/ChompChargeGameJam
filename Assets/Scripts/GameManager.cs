using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioClip currentClip;

    public Pause_Menu pauseMenu;
    public GameObject endMenu;

    // Start is called before the first frame update
    void Start()
    {
        currentClip = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.timeSamples == currentClip.samples)
        {
            pauseMenu.enabled = false;
            endMenu.gameObject.SetActive(true);
        }
    }
}
