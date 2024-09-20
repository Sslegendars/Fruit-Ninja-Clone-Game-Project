using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MultiPlayerLivesGameSceneHandler : ISceneHandler,ISceneHandlerRestartable
{
    private PlayerLives firstPlayerLives;
    private PlayerLives secondPlayerLives;
    private MultiPlayerWinAndLoseData multiPlayerWinAndLoseData;

    public MultiPlayerLivesGameSceneHandler()
    {
       multiPlayerWinAndLoseData = new MultiPlayerWinAndLoseData();     
    }   
    public void Initialize()    
    {
        firstPlayerLives = GameObject.Find("Player1").GetComponent<PlayerLives>();
        secondPlayerLives = GameObject.Find("Player2").GetComponent<PlayerLives>();        
    }
   
    public void GameOver()
    {
        
        if (secondPlayerLives.Lives == 0 )
        {
            HandleGameOver(multiPlayerWinAndLoseData.Player1Wins, UIManager.Instance.multiPlayerHandler.FirstPlayerWin);
        }
        else if (firstPlayerLives.Lives == 0)
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
        UIManager.Instance.multiPlayerHandler.RestartTheUIElements();
        firstPlayerLives.ResetLives();
        secondPlayerLives.ResetLives();
    }
}
