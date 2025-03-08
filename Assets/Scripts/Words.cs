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

    //[SerializeField]
    //private Button m_AddButton;

    //[SerializeField]
    //private int noOfButtons = 2;
    [SerializeField]
    private SpriteRenderer faceColour;

    [SerializeField]
    private Renderer renderer;

    private void Awake()
    {
        wordNotifier = gameEvents;
        //renderer = GetComponent<Renderer>();
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

        StartCoroutine(ChangeBodyColour(Color.green));
    }

    private void OnWrongWord()
    {

        StartCoroutine(ChangeBodyColour(Color.grey));
    }
    
    private IEnumerator ChangeBodyColour(Color targetColor)
    {
        float duration = 5f;
        float timer = 0f;

        Material sharedMat = renderer.sharedMaterial;
       
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
    }

}
/*private IEnumerator ChangeToRed()
    {
        // Changes the face colour to red
        Color colour      = faceColour.color;
        Color startColour = faceColour.color;
        float duriation   = 5f;
        float timer = 0.1f;

        if (faceColour != null)
        {
            while (timer < duriation)
            {
                timer += Time.deltaTime;
                faceColour.color = Color.Lerp(startColour, Color.red, timer);
                yield return new WaitForSeconds(1f);
            }

            colour = faceColour.color;
        }
        else
        {
            Debug.LogError("No face found");
        }
        Debug.Log("Wrong One! Increasing red tint.");
        
    }*/