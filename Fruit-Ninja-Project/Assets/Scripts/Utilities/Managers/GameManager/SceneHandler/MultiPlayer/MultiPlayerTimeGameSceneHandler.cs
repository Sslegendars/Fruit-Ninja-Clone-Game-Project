using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerTimeGameSceneHandler : BaseUsingScoreGameSceneHandler,ISceneHandlerRestartable 
{
    public float gameDuration = 10f;
    private float remainingTime;
    private MultiPlayerWinAndLoseData multiPlayerWinAndLoseData;
    
    public MultiPlayerTimeGameSceneHandler()
    {
        multiPlayerWinAndLoseData = new MultiPlayerWinAndLoseData();
        
    }
    public override void Initialize()
    {
        _blades = new Blade[2];
        _blades[0] = GameObject.Find("Player1").GetComponentInChildren<Blade>();
        _blades[1] = GameObject.Find("Player2").GetComponentInChildren<Blade>();
        base.Initialize();
        remainingTime = gameDuration;
    }
    public override void Update()
    {
        CheckHandleCombo();
        if(GameManager.Instance.GameIsOver == false)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UIManager.Instance.timerHandler.UpdatePlayersTimeText(remainingTime);
            }
            else
            {
                remainingTime = 0;
                UIManager.Instance.timerHandler.UpdatePlayersTimeText(0);
            }
        }      
       
       
        if(remainingTime <= 0 && GameManager.Instance.GameIsOver ==  false)
        {
            GameManager.Instance.GameOver();
        }
    }
    public override void GameOver()
    {
        if(scoreManager.FirstPlayerScore > scoreManager.SecondPlayerScore)
        {
            HandleGameOver(multiPlayerWinAndLoseData.Player1Wins, UIManager.Instance.multiPlayerHandler.FirstPlayerWin);
        }
        else if(scoreManager.FirstPlayerScore < scoreManager.SecondPlayerScore)
        {
            HandleGameOver(multiPlayerWinAndLoseData.Player2Wins, UIManager.Instance.multiPlayerHandler.SecondPlayerWin);
        }
    }
    private void HandleGameOver(System.Action recordWin, System.Action showWinUI)
    {
        recordWin.Invoke();
        showWinUI.Invoke();
        UIManager.Instance.multiPlayerHandler.UpdatePlayersWinAndLoseCountText
        (
            multiPlayerWinAndLoseData.Player1Stats.Wins,
            multiPlayerWinAndLoseData.Player1Stats.Losses,
            multiPlayerWinAndLoseData.Player2Stats.Wins,
            multiPlayerWinAndLoseData.Player2Stats.Losses
        );

    }

    public void RestartTheGame()
    {
        remainingTime = gameDuration;
        UIManager.Instance.multiPlayerHandler.DeactiveUIElements();
        scoreManager.ResetScore();

    }
    
}
