using System;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class StreakUI : MonoBehaviour
{
    // prefab for the text
    [SerializeField] private GameObject streakTextPrefab;
    [SerializeField] private List<Transform> spawnLocations;
    [SerializeField] private float destroyTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ScoreManager>();
        manager.OnPerfectHit += SpawnPerfectText;
        manager.OnStreakMilestone += SpawnStreakText;
        manager.OnGreatestStreakEnded += SpawnGreatestStreakText;
    }

    private void SpawnPerfectText()
    {
        GameObject textObj = Instantiate(streakTextPrefab, spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Count)]);
        textObj.transform.Rotate(0.0f, 0.0f, UnityEngine.Random.Range(-10f, 10f), Space.Self);
        textObj.GetComponent<TextMeshProUGUI>().text = "Perfect!";
        StartCoroutine(DestroyText(textObj));
    }

    private void SpawnStreakText(int streak)
    {
        GameObject textObj = Instantiate(streakTextPrefab, spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Count)]);
        textObj.transform.Rotate(0.0f, 0.0f, UnityEngine.Random.Range(-10f, 10f), Space.Self);
        textObj.GetComponent<TextMeshProUGUI>().text = streak.ToString() + " in a row!";
        StartCoroutine(DestroyText(textObj));
    }
    private void SpawnGreatestStreakText(int streak)
    {
        GameObject textObj = Instantiate(streakTextPrefab, spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Count)]);
        textObj.transform.Rotate(0.0f, 0.0f, UnityEngine.Random.Range(-10f, 10f), Space.Self);
        textObj.GetComponent<TextMeshProUGUI>().text = "New best streak: " + streak.ToString();
        StartCoroutine(DestroyText(textObj));
    }

    private IEnumerator DestroyText(GameObject textToDestroy)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(textToDestroy);
    }
}
