using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    [SerializeField] private LevelData[] levels;
    
    [SerializeField]
    private IWordNotifier wordNotifier;
    [SerializeField]
    private GameEvents gameEvents;

    private int currentLevelIndex = 0;

    private void Awake()
    {
        wordNotifier = gameEvents;

        if (wordNotifier == null)
        {
            Debug.LogError("couldn't find IWordNotifier");
        }
    }
    private void OnEnable()
    {
        wordNotifier.OnCorrectWordSelected += OnCorrectAnswer;
        wordNotifier.OnWrongWordSelected   += OnWrongAnswer;
    }
    private void OnDisable()
    {
        wordNotifier.OnCorrectWordSelected -= OnCorrectAnswer;
        wordNotifier.OnWrongWordSelected -= OnWrongAnswer;
    }
    private void Start()
    {
        LoadLevel(currentLevelIndex);
    }

    private void LoadLevel(int index)
    {
        if (index < levels.Length)
        {
            LevelData level = levels[index];
            gameEvents.CharacterAnimations(level.animationName, level.animationDuration);
            gameEvents.DisplayWords(level.words, level.correctWordIndex);
        }
        else
        {
            Debug.Log("No more levels!");
        }
    }

    public void OnCorrectAnswer()
    {
        Debug.Log("Next Level");
        currentLevelIndex++;
        LoadLevel(currentLevelIndex);
    }

    public void OnWrongAnswer()
    {
       
        
    }
}
