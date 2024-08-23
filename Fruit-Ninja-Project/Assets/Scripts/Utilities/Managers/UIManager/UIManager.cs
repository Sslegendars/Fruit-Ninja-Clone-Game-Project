using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI comboText;
   /* public TextMeshProUGUI gameOverText;
    public Button restartButton;*/

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
    public void ShowComboText(int comboCount, Vector3 bladePosition)
    {        
        switch (comboCount)
        {               
            case 10:                
                SetComboText(comboCount, Color.green);                
                break;
            case 20:                
                SetComboText(comboCount, Color.gray);
                break;
            case 30:                
                SetComboText(comboCount, Color.yellow);
                break;
            case 40:
                SetComboText(comboCount, Color.cyan);
                break;
            case 50:
                SetComboText(comboCount, Color.red);
                break;
            case 60:
                SetComboText(comboCount, Color.white);
                break;       
                            
        }
        ComboTextPosition(bladePosition);
        ActivatedComboText();
        Invoke("DeactivatedComboText", 1f);
    }
    private void ComboTextPosition(Vector3 bladePosition)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(bladePosition);
        comboText.transform.position = screenPosition;
    }
    private void SetComboText(int comboCount, Color color)
    {
        comboText.color = color; 
        comboText.text = comboCount + " POINTS!";
    }
    private void ActivatedComboText()
    {
        comboText.gameObject.SetActive(true);
    }
    private void DeactivatedComboText()
    {
        comboText.gameObject.SetActive(false);
    }

    public void UpdateLivesText(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }
}
