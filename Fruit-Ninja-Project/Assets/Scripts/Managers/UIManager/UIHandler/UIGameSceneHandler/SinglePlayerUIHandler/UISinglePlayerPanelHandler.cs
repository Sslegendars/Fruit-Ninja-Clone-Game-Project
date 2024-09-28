
public class UISinglePlayerPanelHandler : UIPanelHandler
{
    private const string playerPausePanelName = "PlayerPausePanel";
    public void HidePausePanel()
    {
        FindGameObjectInArrayUsingName(playersPausePanel, playerPausePanelName).SetActive(false);
    }
    public void ShowPausePanel()
    {
        FindGameObjectInArrayUsingName(playersPausePanel, playerPausePanelName).SetActive(true);
    }
}
