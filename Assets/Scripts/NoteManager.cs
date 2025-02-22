using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SpawnNote()
    {
        Instantiate(notePrefab, spawnPositions[Random.Range(0, spawnPositions.Count)].position, Quaternion.identity);
    }

}
