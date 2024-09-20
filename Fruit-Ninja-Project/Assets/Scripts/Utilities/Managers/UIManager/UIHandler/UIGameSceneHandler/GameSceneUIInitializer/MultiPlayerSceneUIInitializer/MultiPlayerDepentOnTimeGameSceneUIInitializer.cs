using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiPlayerDepentOnTimeGameSceneUIInitializer : MultiPlayerGameSceneUIInitializer
{
    [Header("Players Time Text Settings")]
    public TextMeshProUGUI[] playersTimeText;
    [Header("Players Combo Text Settings")]
    public TextMeshProUGUI[] playersComboText;
    [Header("Players Score UI Settings")]
    public TextMeshProUGUI firstPlayersScoreText;
    public TextMeshProUGUI secondPlayersScoreText;

    protected override void InitializeUIComponents()
    {
        base.InitializeUIComponents();
        UIManager.Instance.timerHandler.Initialize(playersTimeText);
        UIManager.Instance.comboHandler.Initialize(playersComboText);
        UIManager.Instance.scoreHandler.Initialize(firstPlayersScoreText, secondPlayersScoreText);
    }
}
