using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongLibrary", menuName = "ScriptableObjects/AudioLibrarySO")]
public class AudioLibrarySO : ScriptableObject
{
    public List<SongSO> songs = new List<SongSO>();
}
