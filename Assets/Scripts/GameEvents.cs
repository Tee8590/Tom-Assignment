using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour, IWordNotifier
{
    public event Action OnStartGame;
    public event Action OnWrongWordSelected;
    public event Action OnCorrectWordSelected;
    public event Action<string, float> OnCharacterAnimations;


    public void StartGame()
    {
        OnStartGame?.Invoke();
    }
    public void WrongButton()
   {
       OnWrongWordSelected?.Invoke();
   }
   public void CorrectButton()
   {
       OnCorrectWordSelected?.Invoke();
   }
   public void CharacterAnimations(string animationName, float time)
   {
        if (OnCharacterAnimations != null)
        {
            Debug.Log($"Playing animation: {animationName}");
            OnCharacterAnimations.Invoke(animationName, time);
        }
        else
        {
            Debug.LogWarning("No subscribers for OnCharacterAnimations!");
        }
    }



}
