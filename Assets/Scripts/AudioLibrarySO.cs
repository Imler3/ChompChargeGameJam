using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongLibrary", menuName = "ScriptableObjects/AudioLibrarySO")]
public class AudioLibrarySO : ScriptableObject
{
    public List<SongSO> songs = new List<SongSO>();

    public List<Tuple<string, int>> GetAllSongInfo()
    {
        List<Tuple<string, int>> info = new List<Tuple<string, int>>();
        foreach (SongSO song in songs)
        {
            info.Add(song.GetSongInfo());
        }
        return info;
    }
}
