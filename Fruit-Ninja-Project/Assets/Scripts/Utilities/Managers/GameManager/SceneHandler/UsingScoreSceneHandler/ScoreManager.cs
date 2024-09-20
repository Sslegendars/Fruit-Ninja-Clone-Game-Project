using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager 
{
    public int FirstPlayerScore { get; private set; } = 0;
    public int SecondPlayerScore { get; private set; } = 0;
    

    public void UpdateScore(int playerID,int scorePointsToAdd)
    {   
        if(playerID == 0)
        {
            FirstPlayerScore += scorePointsToAdd;
            UIManager.Instance.scoreHandler.FirstPlayerUpdateScoreText(FirstPlayerScore);
        }
        else if(playerID == 1)
        {
            SecondPlayerScore += scorePointsToAdd;
            UIManager.Instance.scoreHandler.SecondPlayerUpdateScoreText(SecondPlayerScore);
        }
        
    }
    public void ResetScoreWithPlayerID(int playerID)
    {   
        if(playerID == 0)
        {
            FirstPlayerScore = 0;
            UIManager.Instance.scoreHandler.FirstPlayerUpdateScoreText(FirstPlayerScore);
        }
        else if(playerID == 1)
        {
            SecondPlayerScore = 0;
            UIManager.Instance.scoreHandler.SecondPlayerUpdateScoreText(SecondPlayerScore);
        }
        

        
    }
    public void ResetScore()
    {
        FirstPlayerScore = 0;
        SecondPlayerScore = 0;
        UIManager.Instance.scoreHandler.FirstPlayerUpdateScoreText(FirstPlayerScore);        
        UIManager.Instance.scoreHandler.SecondPlayerUpdateScoreText(SecondPlayerScore);
    }
}
