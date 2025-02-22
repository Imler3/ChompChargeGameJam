using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles spawning notes based on beat events from audio manager
public class ClothingManager : MonoBehaviour
{
    public ClothingSO clothingLibraries;
    [SerializeField] private List<GameObject> meters;
    [SerializeField] private SpriteRenderer baseModel;

    [SerializeField] private List<GameObject> locations;

    public event Action<ClothingSO.clothingCategory, int> OnClothingPicked;

    // Start is called before the first frame update
    void Start()
    {
        // load base model
        baseModel.sprite = clothingLibraries.baseModel;

        meters = new List<GameObject>(GameObject.FindGameObjectsWithTag("Meter"));
        foreach (GameObject meter in meters)
        {
            meter.GetComponent<ReceptorMeterUI>().OnMeterFull += PickClothing;
        }
    }

    private void PickClothing(ClothingSO.clothingCategory category)
    {
        // pick a random article of clothing
        int clothingIndex = UnityEngine.Random.Range(0, clothingLibraries.GetNumSprites(category));

        // event to tell the clothing Ui which clothing to settle on
        OnClothingPicked?.Invoke(category, clothingIndex);
    }

    // called by clothingUI after clothing is revealed
    public void SpawnClothing(ClothingSO.clothingCategory category, int clothingIndex)
    {
        // change the sprite of the location
        locations[clothingLibraries.GetLocationAtindex(category, clothingIndex)].GetComponent<SpriteRenderer>().sprite =
            clothingLibraries.GetSpriteAtIndex(category, clothingIndex);
    }

}
