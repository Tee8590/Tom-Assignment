using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private IWordNotifier wordNotifier;
    [SerializeField]
    private GameEvents gameEvents;


    [SerializeField]
    private GameObject TextBox;
    [SerializeField]
    private TextMeshProUGUI textAtStart;
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
        if (wordNotifier != null)
        {
            wordNotifier.OnStartGame +=GameStart  ;
        }
    }
    private void OnDisable()
    {
        if (wordNotifier != null)
        {
            wordNotifier.OnStartGame -=GameStart ;
        }

    }
    void Start()
    {
        GameStart();
    }
    private void GameStart()
    {
        StartCoroutine(StartTheGameText());
    }
    private IEnumerator StartTheGameText()
    {
        
        yield return new WaitForSeconds(2f);
        TextBox.SetActive(true);
        textAtStart.text = "Mother is very sick.....";
        yield return new WaitForSeconds(5f);
        textAtStart.text = "Help her to feel better.....";
        yield return new WaitForSeconds(5f);
        TextBox.SetActive(false);
    }
}
