// contains data about scoring points, referenced by the receptors

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ClothingLibrary", menuName = "ScriptableObjects/ClothingLibrary")]
public class ClothingSO : ScriptableObject
{
    public Sprite baseModel;
    public enum clothingCategory
    {
        accessory,
        top,
        bottom,
        shoe
    }

    public List<Sprite> accessorySprites;
    public List<Vector2> accessoryLocations;
    public List<Sprite> topSprites;
    public List<Vector2> topLocations;
    public List<Sprite> bottomSprites;
    public List<Vector2> bottomLocations;
    public List<Sprite> shoeSprites;
    public List<Vector2> shoeLocations;

    public Sprite GetSpriteAtIndex(clothingCategory category, int index)
    {
        switch (category)
        {
            case clothingCategory.accessory:
                return accessorySprites[index];
            case clothingCategory.top:
                return topSprites[index];
            case clothingCategory.bottom:
                return bottomSprites[index];
            case clothingCategory.shoe:
                return shoeSprites[index];
        }
        throw new Exception("category not valid");
    }

    public Vector2 GetLocationAtindex(clothingCategory category, int index)
    {
        switch (category)
        {
            case clothingCategory.accessory:
                return accessoryLocations[index];
            case clothingCategory.top:
                return topLocations[index];
            case clothingCategory.bottom:
                return bottomLocations[index];
            case clothingCategory.shoe:
                return shoeLocations[index];
        }
        throw new Exception("category not valid");
    }

    public int GetNumSprites(clothingCategory category)
    {
        switch (category)
        {
            case clothingCategory.accessory:
                return accessorySprites.Count;
            case clothingCategory.top:
                return topSprites.Count;
            case clothingCategory.bottom:
                return bottomSprites.Count;
            case clothingCategory.shoe:
                return shoeSprites.Count;
        }
        throw new Exception("category not valid");
    }
}

