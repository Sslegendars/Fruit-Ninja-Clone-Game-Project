using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public bool GameIsOver { get; private set; } = false;
    public ComboSystem comboSystem;
    public Blade _blade;
    
    public int Score { get; private set; } = 0;

    private void Start()
    {
        GameIsStart();        
    }

    private void Update()
    {
        CheckHandleCombo();        
    }
    private void CheckHandleCombo()
    {
        if (comboSystem.IsComboActive)
        {
            HandleCombo();
        }
    }
    private void HandleCombo()
    {
        comboSystem.UpdateCombo(Time.deltaTime);

        if (!comboSystem.IsComboActive)
        {
            int pointsToAdd = CalculateComboPoints();
            UIManager.Instance.ShowComboText(pointsToAdd, _blade.transform.position);
            UpdateScore(pointsToAdd);
            comboSystem.ResetCombo();
        }
    }
    private int CalculateComboPoints()
    {
        int pointsToAdd = 0;

        if (comboSystem.GetComboCount() > comboSystem.minmNumOfFruitsToBeCut)
        {
            pointsToAdd = (comboSystem.GetComboCount() - comboSystem.minmNumOfFruitsToBeCut) * 10;
        }
        
        return pointsToAdd;
    }
   
    public void FruitWasCut()
    {
        UpdateScore(1);
        comboSystem.AddToCombo();          
    }
    private void GameIsStart()
    {
        comboSystem = new ComboSystem();
        UpdateScore(0);
        ActiveSpawnManager();
        UIManager.Instance.HideGameOver();
    }
    public void GameOver()
    {
        GameIsOver = true;
        DeactiveSpawnManager();
        StartCoroutine(ShowGameOverDelay());
    }
    private IEnumerator ShowGameOverDelay()
    {        
        yield return new WaitForSeconds(1.5f);        
        UIManager.Instance.ShowGameOver();
    }
    public void UpdateScore(int scorePointsToAdd)
    {
        Score += scorePointsToAdd;
        UIManager.Instance.UpdateScoreText(Score);
    }
    private void ActiveSpawnManager()
    {
        SpawnManager.Instance.gameObject.SetActive(true);
    }
    private void DeactiveSpawnManager()
    {
        SpawnManager.Instance.gameObject.SetActive(false);
    }
    public void RestartTheGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        UIManager.Instance.HideGameOver();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
