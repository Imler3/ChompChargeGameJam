using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles spawning notes based on beat events from audio manager
public class ScoreManager : MonoBehaviour
{
    public float score = 0.0f;

    [SerializeField] private List<GameObject> receptors;

    public event Action<float> OnScoreUpdated;

    // Start is called before the first frame update
    void Start()
    {
        receptors = new List<GameObject>(GameObject.FindGameObjectsWithTag("Receptor"));
        foreach (GameObject receptor in receptors)
        {
            receptor.GetComponent<Receptor>().OnHit += UpdateScore;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateScore(float points)
    {
        score += points;
        OnScoreUpdated?.Invoke(score);
    }

}
