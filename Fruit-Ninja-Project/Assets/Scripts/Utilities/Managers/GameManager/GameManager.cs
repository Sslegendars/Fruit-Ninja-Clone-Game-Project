using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public bool GameIsOver { get; private set; } = false;
    public ComboSystem comboSystem;
    public int count;
    public Blade _blade;
    
    public int Score { get; private set; } = 0;

    private void Start()
    {
        GameIsStart();
        
    }

    private void Update()
    {
        count = comboSystem.GetComboCount();
        if (comboSystem.IsComboActive)
        {
            comboSystem.UpdateCombo(Time.deltaTime);

            if (!comboSystem.IsComboActive) 
            {
                int pointsToAdd = 0;
                pointsToAdd = comboSystem.GetComboCount() > 2 ? comboSystem.GetComboCount() * 10 : comboSystem.GetComboCount();
                UpdateScore(pointsToAdd);                
                UIManager.Instance.ShowComboText(pointsToAdd, _blade.transform.position);

                comboSystem.ResetCombo();               

            }
        }
        
    }
   
    public void OnFruitCut()
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
}
