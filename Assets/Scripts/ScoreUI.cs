using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "0";

        GameObject.FindGameObjectWithTag("Manager").GetComponent<ScoreManager>().OnScoreUpdated += UpdateText;
    }

    private void UpdateText(float score)
    {
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
}
