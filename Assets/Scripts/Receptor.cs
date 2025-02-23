using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Receptor : MonoBehaviour
{
    [SerializeField] private ScoreMultiplierSO scoreMultiplier;

    private SpriteRenderer theSR;
    private Collider2D col;

    public Sprite defaultImage;
    public Sprite pressedImage;

    public event Action<float> OnHit;

    public event Action OnPerfectHit;


    public enum codes
    {
        up,
        down,
        left,
        right
    }
    public codes key;
    private KeyCode keyToPress;

    private GameObject note = null;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>(); 
        col = GetComponent<Collider2D>();
        col.isTrigger = true;

        switch (key)
        {
            case codes.up:
                keyToPress = KeyCode.UpArrow; break;
            case codes.down:
                keyToPress = KeyCode.DownArrow; break;
            case codes.left:
                keyToPress = KeyCode.LeftArrow; break;
            case codes.right:
                keyToPress = KeyCode.RightArrow; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
            if (note != null) HitNote();
        }
        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            note = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            note = null;
        }
    }

    private void HitNote()
    {
        // calculate score by getting the difference of the horizontal position of the note and the receptor
        float rating = Mathf.Abs(note.transform.position.x - col.transform.position.x);
        // compare against the half the width of the trigger box to get how good a score it was,
        // where 0% is perfect (no difference), and 100% is the full half-width (nearly out of bounds so bad)
        rating = rating / (col.bounds.size.x * 0.5f);

        // and multiply that by number of elements in Scoremultipliers to get the index for the score
        int index = Mathf.FloorToInt(rating * scoreMultiplier.multipliers.Count);
        if (index >= scoreMultiplier.multipliers.Count) { index = scoreMultiplier.multipliers.Count - 1; } // bound

        // send the score to the score manager
        OnHit?.Invoke(scoreMultiplier.multipliers[index]);

        if(index == 0) { OnPerfectHit?.Invoke(); }

        Destroy(note);
    }

}
