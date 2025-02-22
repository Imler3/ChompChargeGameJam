using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform[] spawnPoints;
    public float thisBeatTempo;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = thisBeatTempo / 60f;
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPrefab()
    {
        // If there are available spawn points, choose one randomly
        if (spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            // Instantiate the prefab at the chosen spawn point
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

            ScrollNote scrollScript = spawnedObject.GetComponent<ScrollNote>();
            scrollScript.beatTempo = thisBeatTempo;

            NoteObject nOScript = spawnedObject.GetComponent<NoteObject>();
            if (randomIndex == 0)
            {
                nOScript.keyToPress = KeyCode.UpArrow;
            }
            else if (randomIndex == 1)
            {
                nOScript.keyToPress = KeyCode.RightArrow;
            }
            else if (randomIndex == 2)
            {
                nOScript.keyToPress = KeyCode.LeftArrow;
            }
            else if (randomIndex == 3)
            {
                nOScript.keyToPress = KeyCode.DownArrow;
            }
            
        }
    }
}
