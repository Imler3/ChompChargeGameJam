using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Beat1", menuName = "ScriptableObjects/BeatSO")]
public class BeatSO : ScriptableObject
{
    [Tooltip("How many of the beats to hit; e.g. 1 for every beat, 0.5 for every other, etc.")]
    [SerializeField] private float rate = 1f;

    // keep track of last interval
    private float lastInterval;

    // invoked each time a beat occurs; noteManager listens to this
    public event Action OnBeat;

    public float GetIntervalBetweenBeats(float bpm)
    {
        // return the seconds in the interval between beats
        // get by dividing the bpm*rate (how many beats per minute), convert to secs and take reciprocol
        return 60f / (bpm * rate);
    }

    public void CheckIfNewInterval(float intervalTime)
    {
        // if the interval's whole num part is not the previous one's, it has reached a new interval
        if (Mathf.FloorToInt(intervalTime) != lastInterval)
        {
            // set lastInterval to be this new whole num
            lastInterval = Mathf.FloorToInt(intervalTime);
            OnBeat?.Invoke();
        }
    }
}