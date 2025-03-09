using System;

public interface IWordNotifier
{
    event Action OnStartGame;
    event Action OnWrongWordSelected;
    event Action OnCorrectWordSelected;
    event Action<string, float> OnCharacterAnimations;
}
