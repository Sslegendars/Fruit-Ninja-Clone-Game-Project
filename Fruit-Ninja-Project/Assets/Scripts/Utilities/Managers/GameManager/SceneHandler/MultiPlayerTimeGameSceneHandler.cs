using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerTimeGameSceneHandler : ISceneHandler
{
    public float gameDuration = 60f;
    private float timer;
    public void Initialize()
    {
        timer = gameDuration;
    }
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //GameManager.Instance.EndGameDueToTime();
            GameOver();
        }
    }
    public void GameOver()
    {

    }
}
