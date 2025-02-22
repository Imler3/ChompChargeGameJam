// contains data about scoring points, referenced by the receptors

using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreMultiplier", menuName = "ScriptableObjects/ScoreMultiplier")]
public class ScoreMultiplierSO : ScriptableObject
{
    [Tooltip("List of the points to get for how well you hit the note, lower index is better, higher index is worse")]
    public List<float> multipliers;
}