using UnityEngine;
public class MultiPlayerLivesGameSceneHandler : ISceneHandler,ISceneHandlerRestartable,ISceneHandlerResumable
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
        firstPlayerLives = GameObject.Find("FirstPlayer").GetComponent<PlayerLives>();
        secondPlayerLives = GameObject.Find("SecondPlayer").GetComponent<PlayerLives>();        
    }
   
    public void GameOver()
    {        
        if (secondPlayerLives.Lives == 0 )
        {
            multiPlayerWinAndLoseData.FirstPlayerWin();
        }
        else if (firstPlayerLives.Lives == 0)
        {
            multiPlayerWinAndLoseData.SecondPlayerWin();
        }       
        
    }   

    public void RestartTheGame()
    {          
        UIManager.Instance.multiPlayerPanelHandler.RestartTheUIElements();
        firstPlayerLives.ResetLives();
        secondPlayerLives.ResetLives();
        
    }

    public void ResumeTheGame()
    {
        UIManager.Instance.multiPlayerPanelHandler.HidePausePanels();
    }
}
