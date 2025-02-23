using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DestroyNoteBuffer : MonoBehaviour
{
    private ScoreManager manager;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ScoreManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            Destroy(collision.gameObject);
            manager.ResetStreak();
        }
    }

}
