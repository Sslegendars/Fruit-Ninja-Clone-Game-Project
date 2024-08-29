using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager 
{
    public int Score { get; private set; } = 0;

    public void UpdateScore(int scorePointsToAdd)
    {
        Score += scorePointsToAdd;
        UIManager.Instance.UpdateScoreText(Score);
    }
}
