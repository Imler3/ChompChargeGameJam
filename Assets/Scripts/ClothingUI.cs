using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClothingUI : MonoBehaviour
{

    [SerializeField] private Image img;
    private ClothingManager manager;

    public ClothingSO.clothingCategory category;

    [Tooltip("Seconds to roll before settling")]
    [SerializeField] private float rollTime = 2.0f;
    [Tooltip("How fast to roll")]
    [SerializeField] private float rollSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ClothingManager>();

        manager.OnClothingPicked += StartRollingAnimation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartRollingAnimation(ClothingSO.clothingCategory category, int clothingIndex)
    {
        if (category == this.category) StartCoroutine(rollClothing(category, clothingIndex));
    }

    private IEnumerator rollClothing(ClothingSO.clothingCategory category, int clothingIndex)
    {
        // cycle through random clothing for rollTIme
        float timeInRoll = 0.0f;
        int index;
        while (timeInRoll < rollTime)
        {
            index = UnityEngine.Random.Range(0, manager.clothingLibraries.GetNumSprites(category));
            img.sprite = manager.clothingLibraries.GetSpriteAtIndex(category, index);
            timeInRoll += (1/rollSpeed);
            yield return new WaitForSeconds(1 / rollSpeed);
        }
        // finally, pick the correct one
        img.sprite = manager.clothingLibraries.GetSpriteAtIndex(category, clothingIndex);

        // after rolling, spawn the clothing
        manager.SpawnClothing(category, clothingIndex);
    }

}
