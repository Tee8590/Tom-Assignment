using System;

public interface IWordNotifier
{
    event Action OnWrongWordSelected;
    event Action OnCorrectWordSelected;
}
