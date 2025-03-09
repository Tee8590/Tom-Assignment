using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Level System/Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;         // Name of the level
    public Sprite animationSprite;   // Animation to play
    public string[] wordOptions;     // Words to display (max 5)
    public string correctWord;       // Correct word to proceed
}
