using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Game/LevelData")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public string animationName;
    public float animationDuration;
    public string[] words;
    public int correctWordIndex;
}
