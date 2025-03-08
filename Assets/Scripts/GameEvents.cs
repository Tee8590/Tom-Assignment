using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour, IWordNotifier
{
    public event Action OnWrongWordSelected;
    public event Action OnCorrectWordSelected;


   public void WrongButton()
   {
       OnWrongWordSelected?.Invoke();
   }
    public void CorrectButton()
    {
        OnCorrectWordSelected?.Invoke();
    }
   
   
}
