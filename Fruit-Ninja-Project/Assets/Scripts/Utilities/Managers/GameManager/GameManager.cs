using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public bool GameIsOver { get; private set; } = false;
    private ISceneHandler sceneHandler;   

    protected override void Awake()
    {        
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        //ActivatedSpawnManager();
        
        SceneManagerGetSceneLoaded();
    }
    private void Update()
    {
        if (sceneHandler is ISceneHandlerUpdatable updatable)
        {
            updatable.Update();
        }
    }
    private void SceneManagerGetSceneLoaded()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetGameOverStatus();
        CreateSceneHandler(scene);
        InitializeCurrentSceneHandler();
    }
    private void CreateSceneHandler(Scene scene)
    {
        

        switch (scene.name)
        {
            case "MainMenuScene":
                sceneHandler = new MainMenuSceneHandler();
                SoundToBePlayedWhenMenuSceneStarts();
                break;
            case "MultiPlayerMenuScene":
                sceneHandler = new MultiPlayerMenuSceneHandler();
                SoundToBePlayedWhenMenuSceneStarts();
                break;
            case "SinglePlayerGameScene":
                sceneHandler = new SinglePlayerGameSceneHandler();
                SoundToBePlayedWhenTheGameSceneStarts();
                ActivatedSpawnManager();
                break;
            case "MultiPlayerDepentOnLivesGameScene":
                sceneHandler = new MultiPlayerLivesGameSceneHandler();
                SoundToBePlayedWhenTheGameSceneStarts();
                ActivatedSpawnManager();
                break;
            case "MultiPlayerDepentOnTimeGameScene":
                sceneHandler = new MultiPlayerTimeGameSceneHandler();
                SoundToBePlayedWhenTheGameSceneStarts();
                ActivatedSpawnManager();                
                break;
            default:
                break;
        }
        

    }
    private void InitializeCurrentSceneHandler()
    {
        if (sceneHandler != null)
        {
            sceneHandler.Initialize();
        }
    }
    private void ResetGameOverStatus()
    {
        if (GameIsOver == true)
        {
            ResetGameIsOver();
        }
    }
    private void ResetGameIsOver()
    {
        GameIsOver = false;
    }
    public void GameOver()
    {
        GameIsOver = true;
        DeactivetedSpawnManager();
        StartCoroutine(GameOverDelay());
    }
    public bool ChangeGameIsOverValue(bool gameIsOverValue)
    {        
        return GameIsOver = gameIsOverValue;
    }
    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.gameOverHandler.ShowGameOverPanel();
        sceneHandler.GameOver();
    }
    public void FruitWasCut(int playerID)
    {
        if(sceneHandler is ISceneHandlerFruitCutUpdatable fruitCutUpdatable)
        {
            fruitCutUpdatable.FruitCutUpdate(playerID);
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
        ResetGameIsOver();
        ActivatedSpawnManager();
        if (sceneHandler is ISceneHandlerRestartable restartable)
        {
            restartable.RestartTheGame();
            
        }
        UIManager.Instance.gameOverHandler.HideGameOverPanel();        
    }          
    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
        
    }
    public void LoadMainMenuScene()
    {
        LoadScene("MainMenuScene");        
    }    
    public void LoadMultiPlayerMenuScene()
    {
        LoadScene("MultiPlayerMenuScene");
    }
    public void LoadMultiPlayerDepentOnLivesGameScene()
    {
        LoadScene("MultiPlayerDepentOnLivesGameScene");
    }
    public void LoadMultiPlayerDepentOnTimeGameScene()
    {
        LoadScene("MultiPlayerDepentOnTimeGameScene");
    }
    public void LoadSinglePlayerGameScene()
    {
        LoadScene("SinglePlayerGameScene");
    }   
    public void PlayButtonSound()
    {
        AudioManager.Instance.Play(SoundName.ButtonSound);
    }
    private void SoundToBePlayedWhenMenuSceneStarts()
    {
        AudioManager.Instance.MenuScenePlaySound();
    }
    private void SoundToBePlayedWhenTheGameSceneStarts()
    {
        AudioManager.Instance.GameScenePlaySound();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
