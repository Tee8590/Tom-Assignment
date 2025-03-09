//using System;
//using UnityEngine;

//public class FactoryEvents : MonoBehaviour, IWordNotifier 
//{
//    public event Action<string, float> OnCharacterAnimations;
   
//    public event Action OnWrongWordSelected;
//    public event Action OnCorrectWordSelected;

//    public void CharacterAnimations(string animationName, float time)
//    {
//        OnCharacterAnimations?.Invoke(animationName, time);
//    }

    

//    public void PlayWrongAnimation()
//    {
//        OnWrongWordSelected?.Invoke();
//    }

//    public void CorrectAnswer()
//    {
//        OnCorrectWordSelected?.Invoke();
//    }
//}
