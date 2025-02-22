using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectorUI : MonoBehaviour
{
    [Tooltip("audio manager")]
    [SerializeField] private AudioManager manager;

    [Tooltip("button prefab")]
    [SerializeField] private GameObject buttonPrefab;

    // Update is called once per frame

    public void Start()
    {
        List < Tuple<string, int> > songInfo = manager.songLibrary.GetAllSongInfo();
        for (int i = 0; i < songInfo.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, this.transform);
            newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                newButton.GetComponent<RectTransform>().anchoredPosition.x,
                newButton.GetComponent<RectTransform>().anchoredPosition.y - 1.0f);

            newButton.name = i.ToString();
            newButton.GetComponent<Button>().onClick.AddListener(() => { manager.SelectSong((int)Int32.Parse(newButton.name)); } );
        }
    }

}
