using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDuplicateToPause : MonoBehaviour
{
    public ScoreManager scoreManager;
    private TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + Mathf.FloorToInt(scoreManager.score).ToString();
    }

}
