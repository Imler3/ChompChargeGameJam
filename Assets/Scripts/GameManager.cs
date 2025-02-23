using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private List<GameObject> meters;
    public UnityEvent onAllDone;

    // Start is called before the first frame update
    void Start()
    {
        meters = new List<GameObject>(GameObject.FindGameObjectsWithTag("Meter"));
    }

    // Update is called once per frame
    void Update()
    {
        if (meters[0].GetComponent<ReceptorMeterUI>().done && meters[1].GetComponent<ReceptorMeterUI>().done && meters[2].GetComponent<ReceptorMeterUI>().done && meters[3].GetComponent<ReceptorMeterUI>().done)
        {
            onAllDone.Invoke();
        }
    }
}
