using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    
    public bool gameIsOver = false;
    public int Score { get; private set; } = 0;
    private void Start()
    {
        GameIsStart();
    }

    private void GameIsStart()
    {
        UpdateScore(0);
        ActiveSpawnManager();
        UIManager.Instance.HideGameOver();
    }
    public void GameOver()
    {
        gameIsOver = true;
        DeactiveSpawnManager();
        UIManager.Instance.ShowGameOver();
    }
    
    
    public void UpdateScore(int scorePointsToAdd)
    {
        Score += scorePointsToAdd;
        UIManager.Instance.UpdateScoreText(Score);
    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void ActiveSpawnManager()
    {
        SpawnManager.Instance.gameObject.SetActive(true);
    }
    private void DeactiveSpawnManager()
    {
        SpawnManager.Instance.gameObject.SetActive(false);
    }
}
