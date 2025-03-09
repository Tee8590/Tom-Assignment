using UnityEngine;

public class LevelFactory
{
    public static Level CreateLevel(LevelData data)
    {
        return new Level(data);
    }
}

public class Level
{
    public string LevelName { get; private set; }
    public Sprite AnimationSprite { get; private set; }
    public string[] WordOptions { get; private set; }
    public string CorrectWord { get; private set; }

    public Level(LevelData data)
    {
        LevelName = data.levelName;
        AnimationSprite = data.animationSprite;
        WordOptions = data.wordOptions;
        CorrectWord = data.correctWord;
    }
}
