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
        // Ýstatistiklerin tek bir örneði olacak þekilde sadece ilk seferde oluþturuyoruz.
        multiPlayerWinAndLoseData = new MultiPlayerWinAndLoseData();
        firstPlayerLives = GameObject.Find("Player1").GetComponent<PlayerLives>();
        secondPlayerLives = GameObject.Find("Player2").GetComponent<PlayerLives>();

    }

    public void Initialize()    
    {        
        UIManager.Instance.Player1AndPlayer2PanelsDeactivated();
    }
   
    public void GameOver()
    {
        
        if (secondPlayerLives.Lives == 0 )
        {
            HandleGameOver(multiPlayerWinAndLoseData.Player1Wins, UIManager.Instance.FirstPlayerWin);
        }
        else if (firstPlayerLives.Lives == 0)
        {
            HandleGameOver(multiPlayerWinAndLoseData.Player2Wins, UIManager.Instance.SecondPlayerWin);
        }
        
    }

    private void HandleGameOver(System.Action recordWin, System.Action showWinUI)
    {
        recordWin.Invoke();
        showWinUI.Invoke();
        UIManager.Instance.UpdatePlayersWinAndLoseCountText(
            multiPlayerWinAndLoseData.Player1Stats.Wins,
            multiPlayerWinAndLoseData.Player1Stats.Losses,
            multiPlayerWinAndLoseData.Player2Stats.Wins,
            multiPlayerWinAndLoseData.Player2Stats.Losses
        );
    }

    public void RestartTheGame()
    {   
       
        Initialize();
        firstPlayerLives.ResetLives();
        secondPlayerLives.ResetLives();
    }
}
