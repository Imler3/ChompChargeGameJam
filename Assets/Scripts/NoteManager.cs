using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles spawning notes based on beat events from audio manager
public class NoteManager : MonoBehaviour
{
    [Tooltip("Positions to spawn the notes at; four of them")]
    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] public GameObject notePrefab;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioManager>().OnBeat += SpawnNote;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPrefab()
    {
        // If there are available spawn points, choose one randomly
        if (spawnPositions.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnPositions.Count);
            Transform spawnPoint = spawnPositions[randomIndex];

            // Instantiate the prefab at the chosen spawn point
            GameObject spawnedObject = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);

            //ScrollNote scrollScript = spawnedObject.GetComponent<ScrollNote>();
            //scrollScript.beatTempo = thisBeatTempo;

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
    public void SpawnNote()
    {
        int indexPos = Random.Range(0, spawnPositions.Count);
        GameObject note = Instantiate(notePrefab, spawnPositions[indexPos].position, Quaternion.identity);
        note.transform.GetChild(0).transform.Rotate(0.0f, 0.0f, indexPos * 90.0f, Space.Self);
    }

}
