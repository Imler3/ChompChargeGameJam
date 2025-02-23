using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles spawning notes based on beat events from audio manager
public class ScoreManager : MonoBehaviour
{
    public float score = 0.0f;

    public int streak = 0;

    public int greatestStreak = 0;

    [SerializeField] private List<GameObject> receptors;

    public event Action<float> OnScoreUpdated;
    public event Action<int> OnStreakMilestone;
    public event Action<int> OnGreatestStreakEnded;

    public event Action OnPerfectHit;

    // Start is called before the first frame update
    void Start()
    {
        receptors = new List<GameObject>(GameObject.FindGameObjectsWithTag("Receptor"));
        foreach (GameObject receptor in receptors)
        {
            receptor.GetComponent<Receptor>().OnHit += UpdateScore;
            receptor.GetComponent<Receptor>().OnPerfectHit += PerfectHit;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateScore(float points)
    {
        // get bonus for a streak
        int multiplier = 1;
        if (streak > 0) { multiplier = streak / 5;  }

        score += points * multiplier;
        OnScoreUpdated?.Invoke(score);

        // add 1 to the streak
        streak += 1;
        // every mutliple of 5, send message to streak UI
        if (streak > 0 && streak % 5 == 0)
        {
            OnStreakMilestone?.Invoke(streak);
        }
    }

    // if a note hits the destroy buffer, reset streak
    public void ResetStreak()
    {
        if (streak > greatestStreak)
        {
            OnGreatestStreakEnded?.Invoke(streak);
            greatestStreak = streak;    // update it
        }
        streak = 0; // reset it
    }

    // just perpetuates the perfect hit event to send to UI
    private void PerfectHit()
    {
        OnPerfectHit?.Invoke();
    }

}
