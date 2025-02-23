using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject Canvas;
    public void CloseDialouge()
    {
        Canvas.gameObject.SetActive(false);
    }
   
}
