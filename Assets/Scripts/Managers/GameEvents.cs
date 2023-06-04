using System;
using UnityEngine;

public class GameEvents
{
    // Score events
    public static Action<int> AddScore;
    public static Action UpdateGameUi;
    public static Action ReloadHighScores;

    // Game logic events
    public static Action StartLevel;
    public static Action LevelEnded;
    public static Action RestartCurrentScene;
    public static Action SpawnSheep;
    public static Action PlayerDeath;
    public static Action PlayerWin;
    public static Action<GameObject> AddSheepToList;
    public static Action<GameObject> RemoveSheepFromList;


    // Game time scale events
    public static Action FreezeGame;
    public static Action UnFreezeGame;

    // animation events
    public static Action<string,bool> SetAnimationBool;
    public static Action<string> SetAnimationTrigger;

    // Audio Events
    public static Action<AudioClip> PlaySFX;
   
}
