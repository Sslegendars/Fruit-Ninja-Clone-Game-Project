using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    
    public bool GameIsOver { get; private set; } = false;
    [HideInInspector]
    public ComboSystem comboSystem;
    [HideInInspector]
    public ScoreManager scoreManager;

    //public Blade _blade;

    //public int Score { get; private set; } = 0;

    private ISceneHandler sceneHandler;
    //private MultiPlayerWinAndLoseData multiPlayerWinAndLoseData;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //ActivatedSpawnManager();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void Update()
    {
        
        if (sceneHandler is ISceneHandlerUpdatable updatable)
        {
            updatable.Update();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        /* if (sceneHandler == null)
         {
             CreateSceneHandler(scene);
         }
         else if (scene.name == "MainMenuScene" || scene.name == "MultiPlayerMenuScene")
         {
             // Eðer ana menü sahnesine gidildiðinde yeni bir sahne yöneticisi gerekiyorsa, eski sahne yöneticisini temizleriz.
             CreateSceneHandler(scene);
         }*/
        CreateSceneHandler(scene);

        if (sceneHandler != null)
        {
            sceneHandler.Initialize();
        }
    }
    private void CreateSceneHandler(Scene scene)
    {
        switch (scene.name)
        {
            case "MainMenuScene":
                sceneHandler = new MainMenuSceneHandler();
                break;
            case "MultiPlayerMenuScene":
                sceneHandler = new MultiPlayerMenuSceneHandler();
                Debug.LogError("MultiplayerMenuSceneCalýþtý");
                break;
            case "SinglePlayerGameScene":
                sceneHandler = new SinglePlayerGameSceneHandler();
                ActivatedSpawnManager();
                CallScoreManager();
                CallComboSystem();
                break;
            case "MultiPlayerDepentOnLivesGameScene":
                Debug.LogError("MultiplayeLivesrMenuSceneCalýþtý");
                if (sceneHandler is MultiPlayerLivesGameSceneHandler) return;
                sceneHandler = new MultiPlayerLivesGameSceneHandler();
                ActivatedSpawnManager();
                //CallMultiPlayerGameSceneWinAndLoseData();
                break;
            case "MultiPlayerDepentOnTimeGameScene":
                sceneHandler = new MultiPlayerTimeGameSceneHandler();
                ActivatedSpawnManager();
                CallScoreManager();
                CallComboSystem();
                //CallMultiPlayerGameSceneWinAndLoseData();
                break;
        }
    }

    public void GameOver()
    {
        GameIsOver = true;
        DeactivetedSpawnManager();
        UIManager.Instance.ShowGameOver();
        sceneHandler.GameOver();
        
    }
    public void FruitWasCut()
    {
        if(sceneHandler is MultiPlayerTimeGameSceneHandler || sceneHandler is SinglePlayerGameSceneHandler)
        {
            //UpdateScore(1);
            scoreManager.UpdateScore(1);
            comboSystem.AddToCombo();
        }
    }
    private void ActivatedSpawnManager()
    {
        SpawnManager.Instance.gameObject.SetActive(true);
    }

    private void DeactivetedSpawnManager()
    {
        SpawnManager.Instance.gameObject.SetActive(false);
    }

    public void RestartTheGame()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
        GameIsOver = false;
        ActivatedSpawnManager();
        if (sceneHandler is ISceneHandlerRestartable restartable)
        {
            restartable.RestartTheGame();
            
        }
        UIManager.Instance.HideSinglePlayerGameOver();
        
    }
    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex > 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }
    private void CallComboSystem()
    {
        comboSystem = new ComboSystem();
    }
    private void CallScoreManager()
    {
        scoreManager = new ScoreManager();
    }
    /*private void CallMultiPlayerGameSceneWinAndLoseData()
    {
        multiPlayerWinAndLoseData = new MultiPlayerWinAndLoseData();
    }*/

    // Using Button Onclick Event
    public void LoadScene(string sceneName)
    {
        GameIsOver = false;
        //SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
        
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
