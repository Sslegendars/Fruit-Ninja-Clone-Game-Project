using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerGameSceneHandler : ISceneHandler, ISceneHandlerUpdatable
{
    private ComboSystem comboSystem;
    /* private bool isGameOver = false;
     private float gameOverTimer = 0f;
     private float gameOverDelay = 1f;*/
    private Blade _blade;
    public void Initialize()
    {
        //comboSystem = new ComboSystem();
        comboSystem = GameManager.Instance.comboSystem;
        _blade = GameObject.Find("Player").GetComponentInChildren<Blade>();
        GameManager.Instance.scoreManager.UpdateScore(0);
        //GameManager.Instance.ActivatedSpawnManager();
        UIManager.Instance.HideSinglePlayerGameOver();
        UIManager.Instance.DeactivatedComboText();
    }
    public void Update()
    {
        CheckHandleCombo();
        
        
    }
    private void CheckHandleCombo()
    {
        if (comboSystem != null && comboSystem.IsComboActive)
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
            UIManager.Instance.ShowComboText(pointsToAdd, /*GameManager.Instance.*/_blade.transform.position);
            GameManager.Instance.scoreManager.UpdateScore(pointsToAdd);
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
    public void GameOver()
    {
        SaveBestScore(GameManager.Instance.scoreManager.Score);
        DisplayBestScore();
              
    }
    /*private void GameOverDelay()
    {
        if (GameManager.Instance.GameIsOver)
        {
            gameOverTimer += Time.deltaTime;

            if (gameOverTimer >= gameOverDelay)
            {
                isGameOver = true;

            }
        }
    }*/
    private void SaveBestScore(int currentScore)
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0); // Önceki yüksek skoru al, yoksa 0 al.

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore); // Yeni yüksek skoru kaydet.
            PlayerPrefs.Save(); // Deðiþiklikleri kaydet.
        }
    }
    private void DisplayBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UIManager.Instance.ShowBestScore(bestScore); // Bu metodun UIManager içinde tanýmlý olduðunu varsayýyoruz.
    }

}
