using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Image animationImage;
    [SerializeField] private TextMeshProUGUI[] wordButtons;
    [SerializeField] private GameObject wordPanel;

    public void DisplayLevel(Level level)
    {
        animationImage.sprite = level.AnimationSprite;
        wordPanel.SetActive(true);

        for (int i = 0; i < wordButtons.Length; i++)
        {
            if (i < level.WordOptions.Length)
            {
                wordButtons[i].text = level.WordOptions[i];
                wordButtons[i].gameObject.SetActive(true);
            }
            else
            {
                wordButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void HideWords()
    {
        wordPanel.SetActive(false);
    }
}
