using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.FreezeGame += FreezeGame;
        GameEvents.UnFreezeGame += UnFreezeGame;
    }

    private void OnDisable()
    {
        GameEvents.FreezeGame -= FreezeGame;
        GameEvents.UnFreezeGame -= UnFreezeGame;
    }

    void FreezeGame()
    {
        Time.timeScale= 0;
    }

    void UnFreezeGame()
    {
        Time.timeScale= 1;
    }
}
