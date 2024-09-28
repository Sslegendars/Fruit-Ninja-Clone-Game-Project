using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiPlayerGameSceneUIInitializer : GameSceneUIInitializer
{
    [Header("UI Players Panels Settings")]
    public GameObject[] playersYouWinPanel;
    public GameObject[] playersYouLosePanel;
    [Header("UI Players Win && Lose Count Settings")]
    public TextMeshProUGUI[] playersWinCountText;
    public TextMeshProUGUI[] playersLoseCountText;
    protected override void InitializeUIComponents()
    {
        base.InitializeUIComponents();
        UIManager.Instance.multiPlayerPanelHandler.Initialize(playersYouWinPanel, playersYouLosePanel, playersWinCountText, playersLoseCountText);
        UIManager.Instance.multiPlayerPanelHandler.Initialize(gameOverPanel, pausePanel);
    }
}
