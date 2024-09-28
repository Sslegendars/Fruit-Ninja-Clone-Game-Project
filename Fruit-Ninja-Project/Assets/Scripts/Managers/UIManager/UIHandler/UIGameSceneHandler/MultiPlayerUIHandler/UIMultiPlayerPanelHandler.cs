using UnityEngine;
using TMPro;
using System;

public class UIMultiPlayerPanelHandler : UIPanelHandler
{
    private GameObject[] playersYouWinPanel;
    private GameObject[] playersYouLosePanel;
    private TextMeshProUGUI[] playersWinCountText;
    private TextMeshProUGUI[] playersLoseCountText;
    // First Player 
    private const string firstPlayerYouWinPanelName = "FirstPlayerYouWinPanel";
    private const string firstPlayerYouLosePanelName = "FirstPlayerYouLosePanel";
    private const string firstPlayerWinCountTextName = "FirstPlayerWinCountText";
    private const string firstPlayerLoseCountTextName = "FirstPlayerLoseCountText";
    private const string firstPlayerPausePanelName = "FirstPlayerPausePanel";
    // Second Player
    private const string secondPlayerYouWinPanelName = "SecondPlayerYouwinPanel";
    private const string secondPlayerYouLosePanelName = "SecondPlayerYouLosePanel";
    private const string secondPlayerWinCountTextName = "SecondPlayerWinCountText";
    private const string secondPlayerLoseCountTextName = "SecondPlayerLoseCountText";    
    private const string secondPlayerPausePanelName = "SecondPlayerPausePanel";

    public void Initialize(GameObject[] playersYouWinPanel, GameObject[] playersYouLosePanel, 
                          TextMeshProUGUI[] playersWinCountText, TextMeshProUGUI[] playersLoseCountText)
    {
        this.playersYouWinPanel = playersYouWinPanel;
        this.playersYouLosePanel = playersYouLosePanel;
        this.playersWinCountText = playersWinCountText;
        this.playersLoseCountText = playersLoseCountText;
        DeactiveUIElements();
       
    }
    protected TextMeshProUGUI FindTextInArrayUsingName(TextMeshProUGUI[] gameObjectTexts, string textName)
    {
        return Array.Find(gameObjectTexts, gameObjectText => gameObjectText.name == textName);
    }
    // First Player Panel Activate and Deactivate
    private void FirstPlayerYouWinPanelActivate()
    {       
        FindGameObjectInArrayUsingName(playersYouWinPanel, firstPlayerYouWinPanelName).SetActive(true);        
    }
    private void FirstPlayerYouWinPanelDeactivate()
    {        
        FindGameObjectInArrayUsingName(playersYouWinPanel, firstPlayerYouWinPanelName).SetActive(false);
    }
    private void FirstPlayerYouLosePanelActivate()
    {        
        FindGameObjectInArrayUsingName(playersYouLosePanel, firstPlayerYouLosePanelName).SetActive(true);        
    }
    private void FirstPlayerYouLosePanelDeactivate()
    {
        FindGameObjectInArrayUsingName(playersYouLosePanel, firstPlayerYouLosePanelName).SetActive(false);        
    }
    // First Player WinCountText
    private void FirstPlayerWinCountTextUpdate(int firstPlayerWinCount)
    {
        FirstPlayerWinCountTextActivate();        
        FindTextInArrayUsingName(playersWinCountText, firstPlayerWinCountTextName).text = PlayerWinsString(firstPlayerWinCount);        
    }
    private void FirstPlayerWinCountTextActivate()
    {        
        FindTextInArrayUsingName(playersWinCountText, firstPlayerWinCountTextName).gameObject.SetActive(true);        
    }
    private void FirstPlayerWinCountTextDeactivate()
    {        
        FindTextInArrayUsingName(playersWinCountText, firstPlayerWinCountTextName).gameObject.SetActive(false);        
    }
    // First Player LoseCountText
    private void FirstPlayerLoseCountTextUpdate(int firstPlayerLoseCount)
    {
        FirstPlayerLoseCountTextActivate();        
        FindTextInArrayUsingName(playersLoseCountText, firstPlayerLoseCountTextName).text = PlayerLossesString(firstPlayerLoseCount);        
    }
    private void FirstPlayerLoseCountTextActivate()
    {        
        FindTextInArrayUsingName(playersLoseCountText, firstPlayerLoseCountTextName).gameObject.SetActive(true);        
    }
    private void FirstPlayerLoseCountTextDeactivate()
    {        
        FindTextInArrayUsingName(playersLoseCountText, firstPlayerLoseCountTextName).gameObject.SetActive(false);        
    }
    public void HidePausePanels()
    {
        HideFirstPlayerPausePanel();
        HideSecondPlayerPausePanel();
    }
    public void ShowPausePanels()
    {
        ShowFirstPlayerPausePanel();
        ShowSecondPlayerPausePanel();
    }
    public void DeactiveUIElements()
    {
        FirstPlayerYouWinPanelDeactivate();
        FirstPlayerYouLosePanelDeactivate();
        FirstPlayerWinCountTextDeactivate();
        FirstPlayerLoseCountTextDeactivate();
        SecondPlayerYouWinPanelDeactivate();
        SecondPlayerYouLosePanelDeactivate();
        SecondPlayerWinCountTextDeactivate();
        SecondPlayerLoseCountTextDeactivate();
        
    }
    public void UpdatePlayersWinAndLoseCountText(int firstPlayerWinCount, int firstPlayerLoseCount, int secondPlayerWinCount, int secondPlayerLoseCount)
    {
        FirstPlayerWinCountTextUpdate(firstPlayerWinCount);
        FirstPlayerLoseCountTextUpdate(firstPlayerLoseCount);
        SecondPlayerWinCountTextUpdate(secondPlayerWinCount);
        SecondPlayerLoseCountTextUpdate(secondPlayerLoseCount);
    }
    public void FirstPlayerWin()
    {
        FirstPlayerYouWinPanelActivate();
        SecondPlayerYouLosePanelActivate();
        
    }
    public void SecondPlayerWin()
    {
        SecondPlayerYouWinPanelActivate();
        FirstPlayerYouLosePanelActivate();
       
    }
    // Second Player Panel Activate and Deactivate
    private void SecondPlayerYouWinPanelActivate()
    {        
        FindGameObjectInArrayUsingName(playersYouWinPanel, secondPlayerYouWinPanelName).SetActive(true);        
    }
    private void SecondPlayerYouWinPanelDeactivate()
    {
        FindGameObjectInArrayUsingName(playersYouWinPanel, secondPlayerYouWinPanelName).SetActive(false);
    }
    private void SecondPlayerYouLosePanelActivate()
    {        
        FindGameObjectInArrayUsingName(playersYouLosePanel, secondPlayerYouLosePanelName).SetActive(true);        
    }
    private void SecondPlayerYouLosePanelDeactivate()
    {
        FindGameObjectInArrayUsingName(playersYouLosePanel, secondPlayerYouLosePanelName).SetActive(false);
        
    }
    // Second Player WinCountText
    private void SecondPlayerWinCountTextUpdate(int secondPlayerWinCount)
    {
        SecondPlayerWinCountTextActivate();
        FindTextInArrayUsingName(playersWinCountText, secondPlayerWinCountTextName).text = PlayerWinsString(secondPlayerWinCount);
    }
    private void SecondPlayerWinCountTextActivate()
    {
        FindTextInArrayUsingName(playersWinCountText, secondPlayerWinCountTextName).gameObject.SetActive(true);        
    }
    private void SecondPlayerWinCountTextDeactivate()
    {        
        FindTextInArrayUsingName(playersWinCountText, secondPlayerWinCountTextName).gameObject.SetActive(false);        
    }
    // Second Player LoseCountText
    private void SecondPlayerLoseCountTextUpdate(int secondPlayerLoseCount)
    {
        SecondPlayerLoseCountTextActivate();        
        FindTextInArrayUsingName(playersLoseCountText, secondPlayerLoseCountTextName).text = PlayerLossesString(secondPlayerLoseCount);        
    }
    private void SecondPlayerLoseCountTextActivate()
    {        
        FindTextInArrayUsingName(playersLoseCountText, secondPlayerLoseCountTextName).gameObject.SetActive(true);        
    }
    private void SecondPlayerLoseCountTextDeactivate()
    {        
        FindTextInArrayUsingName(playersLoseCountText, secondPlayerLoseCountTextName).gameObject.SetActive(false);        
    }
    private void HideFirstPlayerPausePanel()
    {
        FindGameObjectInArrayUsingName(playersPausePanel, firstPlayerPausePanelName).SetActive(false);
    }
    private void ShowFirstPlayerPausePanel()
    {
        FindGameObjectInArrayUsingName(playersPausePanel, firstPlayerPausePanelName).SetActive(true);
    }
    private void HideSecondPlayerPausePanel()
    {
        FindGameObjectInArrayUsingName(playersPausePanel, secondPlayerPausePanelName).SetActive(false);
    }
    private void ShowSecondPlayerPausePanel()
    {
        FindGameObjectInArrayUsingName(playersPausePanel, secondPlayerPausePanelName).SetActive(true);
    }
    private string PlayerWinsString(int playerWinCount)
    {
        return "WINS\n" + playerWinCount.ToString();
    }
    private string PlayerLossesString(int playerLoseCount)
    {
        return "LOSSES\n" + playerLoseCount.ToString();
    }

    public void RestartTheUIElements()
    {
        DeactiveUIElements();
    }

    public void Initialize()
    {
        DeactiveUIElements();
    }

    
}
