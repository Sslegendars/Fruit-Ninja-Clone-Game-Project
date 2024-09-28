using UnityEngine;
using System;

public class UIPanelHandler
{
    protected GameObject[] playersPausePanel;
    private GameObject gameOverPanel;  
    public void Initialize(GameObject gameOverPanel, GameObject[] playersPausePanel)
    {
        this.gameOverPanel = gameOverPanel;
        this.playersPausePanel = playersPausePanel;
        HideGameOverPanel();        
    }
    
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }    
    protected GameObject FindGameObjectInArrayUsingName(GameObject[] gameObjectArrays, string gameObjectName)
    {
        return Array.Find(gameObjectArrays, gameobjectArray => gameobjectArray.name == gameObjectName);
    }

    
}
