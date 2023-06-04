using System;

public class GameEvents
{
    // Score events
    public static Action<int> AddScore;
    public static Action UpdateGameUi;
    public static Action ReloadHighScores;

    // Game logic events
    public static Action StartGame;
    public static Action RestartCurrentScene;
    public static Action SpawnSheep;
    public static Action PlayerDeath;

    // Game time scale events
    public static Action FreezeGame;
    public static Action UnFreezeGame;

    // animation events
    public static Action<string,bool> SetAnimationBool;
    public static Action<string> SetAnimationTrigger;
}
