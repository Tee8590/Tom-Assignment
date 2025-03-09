using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<LevelData> levels;  // Assign in Unity Inspector
    [SerializeField] private LevelView levelView;
    [SerializeField] private GameEvents gameEvents;

    private int currentLevelIndex = 0;
    private Level currentLevel;

    private void Start()
    {
        LoadLevel(0);
    }

    public void LoadLevel(int index)
    {
        if (index >= levels.Count) return;

        currentLevelIndex = index;
        currentLevel = LevelFactory.CreateLevel(levels[index]);

        levelView.DisplayLevel(currentLevel);
        gameEvents.StartGame();
    }

    public void OnWordSelected(string selectedWord)
    {
        if (selectedWord == currentLevel.CorrectWord)
        {
            Debug.Log("Correct! Loading next level...");
            levelView.HideWords();
            LoadLevel(currentLevelIndex + 1);
        }
        else
        {
            Debug.Log("Incorrect! Triggering animation...");
            gameEvents.CharacterAnimations("wrong_answer", 2f);
        }
    }
}
