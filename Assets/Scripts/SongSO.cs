using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Song1", menuName = "ScriptableObjects/SongSO")]
public class SongSO : ScriptableObject
{
    public string songName;
    public int difficulty;

    public AudioClip audioFile;
    public float bpm;
    public List<BeatSO> beats = new List<BeatSO>();
}
