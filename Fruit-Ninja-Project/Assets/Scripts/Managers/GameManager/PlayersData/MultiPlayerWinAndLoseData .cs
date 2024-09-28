
public class MultiPlayerWinAndLoseData 
{
    public PlayerStats FirstPlayerStats { get; private set; }    
    public PlayerStats SecondPlayerStats { get; private set; }   
    public MultiPlayerWinAndLoseData()
    {
        FirstPlayerStats = new PlayerStats();
        SecondPlayerStats = new PlayerStats();
    }
    public void FirstPlayerWin()
    {
        IncrementFirstPlayerWin();
        IncrementSecondPlayerLose();
        DisplayGameResults(UIManager.Instance.multiPlayerPanelHandler.FirstPlayerWin);
    }
    public void SecondPlayerWin()
    {
        IncrementSecondPlayerWin();
        IncrementFirstPlayerLose();
        DisplayGameResults(UIManager.Instance.multiPlayerPanelHandler.SecondPlayerWin);
    }
    private void DisplayGameResults(System.Action showWinUI)
    {
        showWinUI.Invoke();
        UIManager.Instance.multiPlayerPanelHandler.UpdatePlayersWinAndLoseCountText
        (
            FirstPlayerStats.Wins,
            FirstPlayerStats.Losses,
            SecondPlayerStats.Wins,
            SecondPlayerStats.Losses
        );

    }
    private void IncrementFirstPlayerWin()
    {
        FirstPlayerStats.Wins++;
    }
    private void IncrementFirstPlayerLose()
    {
        FirstPlayerStats.Losses++;
    }        
    private void IncrementSecondPlayerWin()
    {
        SecondPlayerStats.Wins++;        
    }   
    private void IncrementSecondPlayerLose()
    {
        SecondPlayerStats.Losses++;
    }      
   
}
