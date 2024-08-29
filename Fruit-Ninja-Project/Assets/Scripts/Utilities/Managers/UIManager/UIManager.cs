using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{   
    //
    public GameObject gameOverPanel;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    //
    public TextMeshProUGUI livesTextPlayer1;

    public TextMeshProUGUI livesTextPlayer2;
    public TextMeshProUGUI comboText;
    // Array first element [0] = firstPlayer [1] = secondPlayer
    public GameObject[] youWinPanel;
    public GameObject[] youLosePanel;
    public TextMeshProUGUI[] playerWinCountText;
    public TextMeshProUGUI[] playerLoseCountText;

    //
    public Button restartButton;
    public Button loadPreviousSceneButton;
    public Button quitGameButton;
    public Button mainMenuButton;

    private void Start()
    {
        SetQuitGameButton();
        SetMainMenuButton();
    }
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
    public void Player1AndPlayer2PanelsDeactivated()
    {
        Player1YouWinPanelDeactivated();
        Player1YouLosePanelDeactivated();
        Player2YouWinPanelDeactivated();
        Player2YouLosePanelDeactivated();
        FirstPlayerWinCountTextDeactivated();
        FirstPlayerLoseCountTextDeactivated();
        SecondPlayerWinCountTextDeactivated();
        SecondPlayerLoseCountTextDeactivated();
    }
    public void FirstPlayerWin()
    {
        Player1YouWinPanelActivated();
        Player2YouLosePanelActivated();       
    }
    public void UpdatePlayersWinAndLoseCountText(int firstPlayerWinCount,int firstPlayerLoseCountText, int secondPlayerWinCount, int secondPlayerLoseCount)
    {
        UpdateFirstPlayerWinCountText(firstPlayerWinCount);
        UpdateFirstPlayerLoseCountText(firstPlayerLoseCountText);
        UpdateSecondPlayerWinCountText(secondPlayerWinCount);
        UpdateSecondPlayerLoseCountText(secondPlayerLoseCount);
    }
    public void SecondPlayerWin()
    {
        Player2YouWinPanelActivated();
        Player1YouLosePanelActivated();
    }
    // Player1 panel settings.
    private void Player1YouWinPanelActivated()
    {
        youWinPanel[0].SetActive(true);
    }
    private void Player1YouWinPanelDeactivated()
    {
        youWinPanel[0].SetActive(false);
    }
    private void Player1YouLosePanelActivated()
    {
        youLosePanel[0].SetActive(true);
    }
    private void Player1YouLosePanelDeactivated()
    {
        youLosePanel[0].SetActive(false);
    }
    // player2 Panel settings.
    public void Player2YouWinPanelActivated()
    {
        youWinPanel[1].SetActive(true);
    }
    public void Player2YouWinPanelDeactivated()
    {
        youWinPanel[1].SetActive(false);
    }
    public void Player2YouLosePanelActivated()
    {
        youLosePanel[1].SetActive(true);
    }
    public void Player2YouLosePanelDeactivated()
    {
        youLosePanel[1].SetActive(false);
    }
    // FirstPlayerWinCountText
    private void UpdateFirstPlayerWinCountText(int firstPlayerWinCount)
    {
        FirstPlayerWinCountTextActivated();
        playerWinCountText[0].text = "WINS\n" + firstPlayerWinCount.ToString();
    }
    private void FirstPlayerWinCountTextActivated()
    {
        playerWinCountText[0].gameObject.SetActive(true);
    }
    private void FirstPlayerWinCountTextDeactivated()
    {
        playerWinCountText[0].gameObject.SetActive(false);
    }
    // FirstPlayerLoseCountText
    private void UpdateFirstPlayerLoseCountText(int firstPlayerLoseCount)
    {
        FirstPlayerLoseCountTextActivated();
        playerLoseCountText[0].text = "LOSSES\n" + firstPlayerLoseCount.ToString();
    }   
    private void FirstPlayerLoseCountTextActivated()
    {
        playerLoseCountText[0].gameObject.SetActive(true);
    }
    private void FirstPlayerLoseCountTextDeactivated()
    {
        playerLoseCountText[0].gameObject.SetActive(false);
    }
    // SecondPlayerWinCountText
    private void UpdateSecondPlayerWinCountText(int secondPlayerWinCount)
    {
        SecondPlayerWinCountTextActivated();
        playerWinCountText[1].text = "WINS\n" + secondPlayerWinCount.ToString();
    }
    private void SecondPlayerWinCountTextActivated()
    {
        playerWinCountText[1].gameObject.SetActive(true);
    }
    private void SecondPlayerWinCountTextDeactivated()
    {
        playerWinCountText[1].gameObject.SetActive(false);
    }
    // SecondPlayerLoseCountText
    private void UpdateSecondPlayerLoseCountText(int secondPlayerLoseCount)
    {
        SecondPlayerLoseCountTextActivated();
        playerLoseCountText[1].text = "LOSSES\n" + secondPlayerLoseCount.ToString();
    }
    private void SecondPlayerLoseCountTextActivated()
    {
        playerLoseCountText[1].gameObject.SetActive(true);
    }
    private void SecondPlayerLoseCountTextDeactivated()
    {
        playerLoseCountText[1].gameObject.SetActive(false);
    }
    private void ComboTextPosition(Vector3 bladePosition)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(bladePosition);
        comboText.transform.position = screenPosition;
    }
    private void SetComboText(int comboCount, Color color)
    {
        comboText.color = color;
        comboText.text = comboCount + " \nPOINTS!";
    }
    private void ActivatedComboText()
    {
        comboText.gameObject.SetActive(true);
    }
    public void DeactivatedComboText()
    {
        comboText.gameObject.SetActive(false);
    }
    public void UpdateLivesText(int playerID, int lives)
    {
        if (playerID == 0 && livesTextPlayer1 != null)
        {
            livesTextPlayer1.text = "Lives: " + lives;
        }
        else if (playerID == 1 && livesTextPlayer2 != null)
        {
            livesTextPlayer2.text = "Lives: " + lives;
        }

    }
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        SetRestartButton();
        SetLoadPreviousSceneButton();
    }
    private void SetLoadPreviousSceneButton()
    {
       loadPreviousSceneButton.onClick.AddListener(GameManager.Instance.LoadPreviousScene);
    }
    private void SetRestartButton()
    {
        restartButton.onClick.AddListener(GameManager.Instance.RestartTheGame);
    }
    private void SetQuitGameButton()
    {
        quitGameButton.onClick.AddListener(GameManager.Instance.QuitGame);
    }
    private void SetMainMenuButton()
    {
        mainMenuButton.onClick.AddListener(GameManager.Instance.LoadMainMenuScene);
    }
    public void HideSinglePlayerGameOver()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowBestScore(int bestScore)
    {
        bestScoreText.text = "Best Score\n" + bestScore.ToString();
    }   
}
