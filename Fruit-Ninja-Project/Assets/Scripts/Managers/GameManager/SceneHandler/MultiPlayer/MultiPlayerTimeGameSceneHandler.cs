using UnityEngine;
public class MultiPlayerTimeGameSceneHandler : BaseUsingScoreGameSceneHandler,ISceneHandlerRestartable 
{
    private float gameDuration = 60f;
    private float remainingTime;
    private MultiPlayerWinAndLoseData multiPlayerWinAndLoseData;
    
    public MultiPlayerTimeGameSceneHandler()
    {
        multiPlayerWinAndLoseData = new MultiPlayerWinAndLoseData();
        
    }
    public override void Initialize()
    {
                
        _blades = new Blade[2];
        _blades[0] = GameObject.Find("FirstPlayer").GetComponentInChildren<Blade>();
        _blades[1] = GameObject.Find("SecondPlayer").GetComponentInChildren<Blade>();
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
        if (scoreManager.FirstPlayerScore > scoreManager.SecondPlayerScore)
        {
            multiPlayerWinAndLoseData.FirstPlayerWin();
        }
        else if (scoreManager.FirstPlayerScore < scoreManager.SecondPlayerScore)
        {
            multiPlayerWinAndLoseData.SecondPlayerWin();
        }
    }   

    public void RestartTheGame()
    {
        remainingTime = gameDuration;
        UIManager.Instance.multiPlayerPanelHandler.DeactiveUIElements();
        scoreManager.ResetScore();

    }
    public override void ResumeTheGame()
    {
        UIManager.Instance.multiPlayerPanelHandler.HidePausePanels();
    }
}
