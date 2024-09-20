using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverHandler 
{
    public GameObject gameOverPanel;
    public void Intialize(GameObject gameOverPanel)
    {
        this.gameOverPanel = gameOverPanel;
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
}
