using UnityEngine;
using TMPro;

public class MultiPlayerDepentOnTimeGameSceneUIInitializer : MultiPlayerGameSceneUIInitializer
{
    [Header("Players Time Text Settings")]
    [SerializeField]
    private TextMeshProUGUI[] playersTimeText;
    [Header("Players Combo Text Settings")]
    [SerializeField]
    private TextMeshProUGUI[] playersComboText;
    [Header("Players Score UI Settings")]
    [SerializeField]
    private TextMeshProUGUI firstPlayerScoreText;
    [SerializeField]
    private TextMeshProUGUI secondPlayerScoreText;

    protected override void InitializeUIComponents()
    {
        base.InitializeUIComponents();
        UIManager.Instance.timerHandler.Initialize(playersTimeText);
        UIManager.Instance.comboHandler.Initialize(playersComboText);
        UIManager.Instance.scoreHandler.Initialize(firstPlayerScoreText, secondPlayerScoreText);
    }
}
