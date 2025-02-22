using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Tooltip("Scriptable object that holds list of audio clips")]
    [SerializeField] private AudioLibrarySO songLibrary;

    [Tooltip("Index of current song in the songLibrary")]
    [SerializeField] private int currentSong = 0;

    [Tooltip("AudioSource, so the camera can hear")]
    [SerializeField] private AudioSource audioSource;

    // invoked each time a beat occurs; noteManager listens to this
    public event Action OnBeat;

    // Start is called before the first frame update
    void Start()
    {
        SelectSong(0);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
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
    }

    // just invokes audioManager's OnBeat event whenever a beat's OnBeat event is invoked
    private void CallOnBeat()
    {
        this.OnBeat?.Invoke();
    }

}
