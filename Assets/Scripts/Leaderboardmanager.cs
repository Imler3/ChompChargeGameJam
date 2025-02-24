using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// handles spawning notes based on beat events from audio manager
public class LeaderboardManager : MonoBehaviour
{
    public Leaderboard leaderboard = new Leaderboard(0);
    private string filename;
    private int score;
    private int indexToInsert = -1;
    [SerializeField] private GameObject nameInput;
    [SerializeField] private TextMeshProUGUI LBtext;

    public void Start()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>().OnSongEnd += ShowLeaderboard;
    }

    private void ShowLeaderboard()
    {
        nameInput.SetActive(false);
        filename = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>().currentSong.ToString() + "_song_leaderboard.txt";
        score = Mathf.FloorToInt(GameObject.FindGameObjectWithTag("Manager").GetComponent<ScoreManager>().score);
        Debug.Log(score);

        if (LoadLeaderboard())
        {
            // find place to insert
            for (int i = 0; i < leaderboard.scores.Length; i++)
            {
                if (leaderboard.scores[i] < score)
                {
                    // then i is where to insert the new score
                    indexToInsert = i;
                    break;
                }
            }
        }
        else indexToInsert = 0;

        if (indexToInsert >= 0 )
        {
            // create new arrays
            int sizeOfNewLB = leaderboard.names.Length + 1;
            Debug.Log(sizeOfNewLB);
            if (sizeOfNewLB > 5) sizeOfNewLB = 5;
            string[] newNames = new string[sizeOfNewLB];
            int[] newScores = new int[sizeOfNewLB];
            string[] newDates = new string[sizeOfNewLB];

            // copy
            for (int i = 0; i < newNames.Length; i++)
            {
                Debug.Log(i);
                if (i == indexToInsert)
                {
                    newNames[i] = "YOU!!";
                    newScores[i] = score;
                    newDates[i] = DateTime.Now.ToString();
                    continue;
                }
                else if (i < indexToInsert)
                {
                    newNames[i] = leaderboard.names[i];
                    newScores[i] = leaderboard.scores[i];
                    newDates[i] = leaderboard.dates[i];
                }
                else
                {
                    newNames[i] = leaderboard.names[i - 1];
                    newScores[i] = leaderboard.scores[i - 1];
                    newDates[i] = leaderboard.dates[i - 1];
                }
            }
            // set the leaderboard
            leaderboard.names = newNames;
            leaderboard.scores = newScores;
            leaderboard.dates = newDates;
            Debug.Log(leaderboard);
            SaveLeaderboard();
            LoadLeaderboard();
            DisplayLeaderboard();

            nameInput.SetActive(true);
            Debug.Log("set active");
            nameInput.GetComponent<TMP_InputField>().onSubmit.AddListener((string text) => { AddName(text); });
        }
    }

    public void AddName(string name)
    {
        leaderboard.names[indexToInsert] = name;
        SaveLeaderboard();
        DisplayLeaderboard();
        nameInput.SetActive(false);
        indexToInsert = -1;
    }
    
    public bool LoadLeaderboard()
    {
        if (File.Exists(Application.persistentDataPath + "/" + filename))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/" + filename);
            leaderboard = JsonUtility.FromJson<Leaderboard>(json);
            Debug.Log("File at " + Application.persistentDataPath + "/" + filename);
            return true;
        }
        else Debug.Log("No file at " + Application.persistentDataPath + "/" + filename);
        return false;
    }

    public void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(leaderboard);
        File.WriteAllText(Application.persistentDataPath + "/" + filename, json);
    }

    public void DisplayLeaderboard()
    {
        LBtext.text = "";
        for (int i = 0; i < leaderboard.names.Length; i++)
        {
            LBtext.text += (i + 1) + ") " + leaderboard.names[i] + ": " + leaderboard.scores[i] + " | " + leaderboard.dates[i] + "\n";
        }
    }


}

[Serializable]
public struct Leaderboard
{
    public string[] names;
    public int[] scores;
    public string[] dates;

    public Leaderboard(int i)
    {
        names = new string[i];
        scores = new int[i];
        dates = new string[i];
    }
}
