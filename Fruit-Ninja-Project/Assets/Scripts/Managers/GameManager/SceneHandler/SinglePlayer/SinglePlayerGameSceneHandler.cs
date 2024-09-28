using UnityEngine;
public class SinglePlayerGameSceneHandler : BaseUsingScoreGameSceneHandler,ISceneHandlerRestartable
{
    private PlayerLives playerLives;    
    public override void Initialize()
    {
        GameObject playerObject = GameObject.Find("Player");
        if(playerObject != null)
        {
            playerLives = playerObject.GetComponent<PlayerLives>();
            _blades = new Blade[1];
            _blades[0] = playerObject.GetComponentInChildren<Blade>();
        }
        else
        {
            return;
        }
        base.Initialize();              
                                     
    }
    public override void Update()
    {
        CheckHandleCombo();       
    }
      
    public override void GameOver()
    {
        SaveBestScore(scoreManager.FirstPlayerScore);
        DisplayBestScore();
              
    }
    private void SaveBestScore(int currentScore)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0); 

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore); 
            PlayerPrefs.Save(); 
        }
    }
    private void DisplayBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UIManager.Instance.bestScoreHandler.ShowBestScore(bestScore); 
        
    }
    public void RestartTheGame()
    {
        playerLives.ResetLives();        
        scoreManager.ResetScoreWithPlayerID(playerLives.playerID);
        UIManager.Instance.singlePlayerPanelHandler.HidePausePanel();
    }
    public override void ResumeTheGame()
    {
        UIManager.Instance.singlePlayerPanelHandler.HidePausePanel();
    }
    


}

