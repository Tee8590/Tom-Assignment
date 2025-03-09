using System.Collections;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField]
    private IWordNotifier wordNotifier;
    [SerializeField]
    private GameEvents gameEvents;

    [SerializeField]
    Animator charAnimator; 
    private void Awake()
    {
        wordNotifier = gameEvents;
        //render = GetComponent<Renderer>();
        if (wordNotifier == null)
        {
            Debug.LogError("couldn't find IWordNotifier");
        }
    }
    private void OnEnable()
    {
        if (wordNotifier != null)
        {
            wordNotifier.OnCharacterAnimations += OnAnimation;
        }
    }
    private void OnDisable()
    {
        if (wordNotifier != null)
        {
            wordNotifier.OnCharacterAnimations -= OnAnimation;
        }

    }
    private void OnAnimation(string animationName, float time)
    {
        if (charAnimator == null)
        {
            Debug.LogError("Animator not assigned!");
            return;
        }
        StartCoroutine(AnimationControl(animationName, time));
        // Play the animation
        //charAnimator.Play(animationName);
    }
    private IEnumerator AnimationControl( string animationName, float time)
    {
        charAnimator.Play(animationName);
        yield return new WaitForSeconds(time);
        charAnimator.Play("idle");
    }
}

