using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles spawning notes based on beat events from audio manager
public class SelectModel : MonoBehaviour
{
    public ClothingSO clothingLibrary;

    public void SetModel(Sprite model)
    {
        clothingLibrary.baseModel = model;
    }


}
