using UnityEngine;
using TMPro;
public class MultiPlayerDepentOnLivesGameSceneUIIntializer : MultiPlayerGameSceneUIInitializer
{   
    [Header("UI Players Lives Settings")]
    [SerializeField]
    private TextMeshProUGUI firstPlayerLivesText;
    [SerializeField]
    private TextMeshProUGUI secondPlayerLivesText;  
    
    protected override void InitializeUIComponents()
    {
        base.InitializeUIComponents();        
        UIManager.Instance.livesHandler.Initialize(firstPlayerLivesText, secondPlayerLivesText);
        
        
    }
}
