using UnityEngine;
using TMPro;

public class UIHandlerSinglePlayerGameSceneInitializer : GameSceneUIInitializer
{
    [Header("PlayerText")]
    public TextMeshProUGUI playerLivesText;
    [Header("UI Player Score Text Settings")]
    public TextMeshProUGUI firstScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI[] comboText;  
    
    protected override void InitializeUIComponents()
    {
        base.InitializeUIComponents();
        UIManager.Instance.scoreHandler.Initialize(firstScoreText, null);
        UIManager.Instance.bestScoreHandler.Initialize(bestScoreText);
        UIManager.Instance.comboHandler.Initialize(comboText);
        UIManager.Instance.livesHandler.Initialize(playerLivesText, null);
    }

}
