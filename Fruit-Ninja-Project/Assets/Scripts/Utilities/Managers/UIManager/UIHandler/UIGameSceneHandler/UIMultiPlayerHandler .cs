using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandlerMultiPlayer 
{
    public GameObject[] playersYouWinPanel;
    public GameObject[] playersYouLosePanel;
    public TextMeshProUGUI[] playersWinCountText;
    public TextMeshProUGUI[] playersLoseCountText;

    public void Initialize(GameObject[] playersYouWinPanel, GameObject[] playersYouLosePanel, 
                          TextMeshProUGUI[] playersWinCountText, TextMeshProUGUI[] playersLoseCountText)
    {
        this.playersYouWinPanel = playersYouWinPanel;
        this.playersYouLosePanel = playersYouLosePanel;
        this.playersWinCountText = playersWinCountText;
        this.playersLoseCountText = playersLoseCountText;
        DeactiveUIElements();
       
    }
    public TextMeshProUGUI FindTextByName(TextMeshProUGUI[] playersCountText, string name)
    {
        foreach (TextMeshProUGUI text in playersCountText)
        {
            if (text.name == name)
            {
                return text;
            }
        }
        return null;
    }
    public GameObject FindPanelByName(GameObject[] playerPanels,string name)
    {
        foreach (GameObject panel in playerPanels)
        {
            if (panel.name == name)
            {
                return panel;
            }
        }
        return null;
    }
    // First Player Panel Activate and Deactivate
    private void FirstPlayerYouWinPanelActivate()
    {
        //UIManager.Instance.ShowUIGameObject(playersYouWinPanel[0]);
        
        playersYouWinPanel[0].SetActive(true);
    }
    private void FirstPlayerYouWinPanelDeactivate()
    {
        // UIManager.Instance.HideUIGameObject(playersYouWinPanel[0]);
        playersYouWinPanel[0].SetActive(false);
    }
    private void FirstPlayerYouLosePanelActivate()
    {
        //UIManager.Instance.ShowUIGameObject(playersYouLosePanel[0]);
        playersYouLosePanel[0].SetActive(true);
    }
    private void FirstPlayerYouLosePanelDeactivate()
    {
        //UIManager.Instance.HideUIGameObject(playersYouLosePanel[0]);
        playersYouLosePanel[0].SetActive(false);
    }
    // First Player WinCountText
    private void FirstPlayerWinCountTextUpdate(int firstPlayerWinCount)
    {
        FirstPlayerWinCountTextActivate();
        //UIManager.Instance.SetTextString(playersWinCountText[0], "WINS\n" + firstPlayerWinCount.ToString());
        playersWinCountText[0].text = PlayerWinsString(firstPlayerWinCount);
    }
    private void FirstPlayerWinCountTextActivate()
    {
        //UIManager.Instance.ShowUIGameObject(playersWinCountText[0].gameObject);
        playersWinCountText[0].gameObject.SetActive(true);
    }
    private void FirstPlayerWinCountTextDeactivate()
    {
        //UIManager.Instance.HideUIGameObject(playersWinCountText[0].gameObject);
        playersWinCountText[0].gameObject.SetActive(false);
    }
    // First Player LoseCountText
    private void FirstPlayerLoseCountTextUpdate(int firstPlayerLoseCount)
    {
        FirstPlayerLoseCountTextActivate();
        //UIManager.Instance.SetTextString(playersLoseCountText[0], "LOSSES\n" + firstPlayerLoseCount.ToString());
        playersLoseCountText[0].text = PlayerLossesString(firstPlayerLoseCount);
    }
    private void FirstPlayerLoseCountTextActivate()
    {
        //UIManager.Instance.ShowUIGameObject(playersLoseCountText[0].gameObject);
        playersLoseCountText[0].gameObject.SetActive(true);
    }
    private void FirstPlayerLoseCountTextDeactivate()
    {
        //UIManager.Instance.HideUIGameObject(playersLoseCountText[0].gameObject);
        playersLoseCountText[0].gameObject.SetActive(false);
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
        //UIManager.Instance.ShowUIGameObject(playersYouWinPanel[1]);
        playersYouWinPanel[1].SetActive(true);
    }
    private void SecondPlayerYouWinPanelDeactivate()
    {
        //UIManager.Instance.HideUIGameObject(playersYouWinPanel[1]);
        playersYouWinPanel[1].SetActive(false);
    }
    private void SecondPlayerYouLosePanelActivate()
    {
        //UIManager.Instance.ShowUIGameObject(playersYouLosePanel[1]);
        playersYouLosePanel[1].SetActive(true);
    }
    private void SecondPlayerYouLosePanelDeactivate()
    {
        //UIManager.Instance.HideUIGameObject(playersYouLosePanel[1]);
        playersYouLosePanel[1].SetActive(false);
    }
    // Second Player WinCountText
    private void SecondPlayerWinCountTextUpdate(int secondPlayerWinCount)
    {
        SecondPlayerWinCountTextActivate();
        //UIManager.Instance.SetTextString(playersWinCountText[1], "WINS\n" + secondPlayerWinCount.ToString());
        playersWinCountText[1].text = PlayerWinsString(secondPlayerWinCount);
    }
    private void SecondPlayerWinCountTextActivate()
    {
        //UIManager.Instance.ShowUIGameObject(playersWinCountText[1].gameObject);
        playersWinCountText[1].gameObject.SetActive(true);
    }
    private void SecondPlayerWinCountTextDeactivate()
    {
        //UIManager.Instance.HideUIGameObject(playersWinCountText[1].gameObject);
        playersWinCountText[1].gameObject.SetActive(false);
    }
    // Second Player LoseCountText
    private void SecondPlayerLoseCountTextUpdate(int secondPlayerLoseCount)
    {
        SecondPlayerLoseCountTextActivate();
        //UIManager.Instance.SetTextString(playersLoseCountText[1], "LOSSES\n" + secondPlayerLoseCount.ToString());
        playersLoseCountText[1].text = PlayerLossesString(secondPlayerLoseCount);
    }
    private void SecondPlayerLoseCountTextActivate()
    {
        //UIManager.Instance.ShowUIGameObject(playersLoseCountText[1].gameObject);
        playersLoseCountText[1].gameObject.SetActive(true);
    }
    private void SecondPlayerLoseCountTextDeactivate()
    {
        //UIManager.Instance.HideUIGameObject(playersLoseCountText[1].gameObject);
        playersLoseCountText[1].gameObject.SetActive(false);
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





    // restart button buraya konabiliri
}
