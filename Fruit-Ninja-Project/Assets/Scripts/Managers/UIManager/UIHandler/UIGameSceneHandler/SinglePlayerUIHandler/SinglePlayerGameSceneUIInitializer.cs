using UnityEngine;
using TMPro;
public class SinglePlayerGameSceneUIInitializer : GameSceneUIInitializer
{
    [Header("PlayerText")]
    [SerializeField]
    private TextMeshProUGUI playerLivesText;
    [Header("UI Player Score Text Settings")]
    [SerializeField]
    private TextMeshProUGUI firstScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMeshProUGUI[] comboText;  
       
    protected override void InitializeUIComponents()
    {
        
        base.InitializeUIComponents();
        UIManager.Instance.singlePlayerPanelHandler.Initialize(gameOverPanel, pausePanel); 
        UIManager.Instance.scoreHandler.Initialize(firstScoreText, null);
        UIManager.Instance.bestScoreHandler.Initialize(bestScoreText);
        UIManager.Instance.comboHandler.Initialize(comboText);
        UIManager.Instance.livesHandler.Initialize(playerLivesText, null);
    }

}
