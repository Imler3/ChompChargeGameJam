// reference: https://youtu.be/gIjajeyjRfE?feature=shared by b3agz

// handles changing and playing songs and triggering beats

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Tooltip("Scriptable object that holds list of audio clips")]
    public AudioLibrarySO songLibrary;

    [Tooltip("Index of current song in the songLibrary")]
    [SerializeField] private int currentSong = 0;

    [Tooltip("AudioSource, so the camera can hear")]
    [SerializeField] private AudioSource audioSource;

    [Header("Objects to show/hide")]
    [Tooltip("select system game object")]
    [SerializeField] private GameObject selectSystem;
    [Tooltip("music system game object")]
    [SerializeField] private GameObject musicSystem;

    public Pause_Menu pauseManu;

    // invoked each time a beat occurs; noteManager listens to this
    public event Action OnBeat;

    public bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            foreach (BeatSO beat in songLibrary.songs[currentSong].beats)
            {
                // all this just to convert samples to beats!

                // get the elapsed beats = 

                // GetIntervalBetweenBeats(bpm) gives secs-per-beat
                // frequency gives samples-per-sec
                // multiply them to get samples-per-beat

                // take timeSamples divided by samples-per-beat to get elapsed beats
                // divide the playback position (timeSamples) by the sample frequency to get
                float sampledTime = audioSource.timeSamples /
                    (audioSource.clip.frequency * beat.GetIntervalBetweenBeats(songLibrary.songs[currentSong].bpm));
                beat.CheckIfNewInterval(sampledTime);   // invokes OnBeat if new interval reached

            }
        }
        if (isPlaying && !audioSource.isPlaying)
        {
            isPlaying = false;
            audioSource.Stop();
        }
    }

    public void SelectSong(int index)
    {
        // remove listeners from previous song
        foreach (BeatSO beat in songLibrary.songs[currentSong].beats)
        {
            beat.OnBeat -= CallOnBeat;
        }

        // change index
        currentSong = index;

        // add listeners to new song
        foreach (BeatSO beat in songLibrary.songs[currentSong].beats)
        {
            beat.OnBeat += CallOnBeat;
        }
        // change audioSource clip
        audioSource.clip = songLibrary.songs[currentSong].audioFile;

        ChangeObjs();

        pauseManu.enabled = true;

        isPlaying = true;
        audioSource.Play();
    }

    public void StartStopSong(bool isStart)
    {
        if (isStart)
        {
            isPlaying = true;
            audioSource.Play();
        }
        else
        {
            isPlaying = false;
            audioSource.Pause();
        }
    }

    private void ChangeObjs()
    {
        selectSystem.SetActive(false);
        musicSystem.SetActive(true);
    }

    // just invokes audioManager's OnBeat event whenever a beat's OnBeat event is invoked
    private void CallOnBeat()
    {
        this.OnBeat?.Invoke();
    }

}
