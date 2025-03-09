using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    [SerializeField] private TextMeshProUGUI[] wordButtons;

    private int correctIndex;

    private void OnEnable()
    {
        gameEvents.OnDisplayWords += DisplayWords;
    }

    private void OnDisable()
    {
        gameEvents.OnDisplayWords -= DisplayWords;
    }

    private void DisplayWords(string[] words, int correctIndex)
    {
        this.correctIndex = correctIndex;

        if (wordButtons == null || wordButtons.Length == 0)
        {
            Debug.LogError("wordButtons array is not assigned in the Inspector!");
            return;
        }

        for (int i = 0; i < wordButtons.Length; i++)
        {
            if (i < words.Length)
            {
                if (wordButtons[i] == null)
                {
                    Debug.LogError($"wordButtons[{i}] is null!");
                    continue;
                }

                wordButtons[i].text = words[i];
                wordButtons[i].gameObject.SetActive(true);

                Button buttonComponent = wordButtons[i].GetComponentInParent<Button>();
                if (buttonComponent == null)
                {
                    Debug.LogError($"Button component missing on wordButtons[{i}]!");
                    continue;
                }

                buttonComponent.onClick.RemoveAllListeners(); // Fix duplicate event issue
                int index = i;
                buttonComponent.onClick.AddListener(() => OnWordSelected(index));
            }
            else
            {
                if (wordButtons[i] != null)
                    wordButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnWordSelected(int index)
    {
        if (index == correctIndex)
        {
            Debug.Log("qw");
            gameEvents.CorrectButton();
            
        }
        else
        {
            gameEvents.WrongButton();
        }
    }
}
