using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Words : MonoBehaviour
{
    [SerializeField]
    private IWordNotifier wordNotifier;
    [SerializeField]
    private GameEvents gameEvents;

    [SerializeField]
    private GameObject buttons;

    //[SerializeField]
    //private int noOfButtons = 2;
    [SerializeField]
    private SpriteRenderer faceColour;

    [SerializeField]
    private Renderer render ;

    private void Awake()
    {
        wordNotifier = gameEvents;
        
        if(wordNotifier ==null)
        {
            Debug.LogError("couldn't find IWordNotifier");
        }
    }
    private void OnEnable()
    {
        if(wordNotifier !=null)
        {
            wordNotifier.OnWrongWordSelected   += OnWrongWord;
            wordNotifier.OnCorrectWordSelected += OnCorrectWord;
        }
    }
    private void OnDisable()
    {
        if(wordNotifier != null)
        {
            wordNotifier.OnWrongWordSelected   -= OnWrongWord;
            wordNotifier.OnCorrectWordSelected -= OnCorrectWord;
        }
    }
    private void OnCorrectWord()
    {

        StartCoroutine(ChangeBodyColour(new Color(1, 0.2f, 0)));
        gameEvents.CharacterAnimations("blocking hit",2f);
    }

    private void OnWrongWord()
    {

        StartCoroutine(ChangeBodyColour(Color.red));
        gameEvents.CharacterAnimations("blocking hit", 2f);
    }
    
    private IEnumerator ChangeBodyColour(Color targetColor)
    {

        SetButtonsActive(false);

        float duration = 2f;
        float timer = 0f;

        Material sharedMat = render.sharedMaterial;
       
        Color originalColor = sharedMat.GetColor("_primary_Colour");

        while (timer < duration)
        {
            sharedMat.SetColor("_primary_Colour", targetColor);
            yield return new WaitForSeconds(0.5f); 
            timer += 0.5f;
            sharedMat.SetColor("_primary_Colour", originalColor);
            yield return new WaitForSeconds(0.1f);
        }
        sharedMat.SetColor("_primary_Colour", originalColor);

        SetButtonsActive(true);
    }
    private void SetButtonsActive(bool isActive)
    {
        buttons.gameObject.SetActive(isActive);
    }

}
