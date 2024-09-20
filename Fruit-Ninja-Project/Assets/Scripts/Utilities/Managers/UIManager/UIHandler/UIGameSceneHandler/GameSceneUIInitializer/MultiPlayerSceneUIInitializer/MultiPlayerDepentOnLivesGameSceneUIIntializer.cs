using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MultiPlayerDepentOnLivesGameSceneUIIntializer : MultiPlayerGameSceneUIInitializer
{   
    [Header("UI Players Lives Settings")]
    public TextMeshProUGUI firstPlayerLivesText;
    public TextMeshProUGUI secondPlayerLivesText;  
    
    protected override void InitializeUIComponents()
    {
        base.InitializeUIComponents();        
        UIManager.Instance.livesHandler.Initialize(firstPlayerLivesText, secondPlayerLivesText);        
        
    }
}
