using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoSingleton<GameManager>
{
    public bool GameIsOver { get; private set; } = false;
    private bool isGamePaused = false;    
    private ISceneHandler sceneHandler;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        SceneManagerGetSceneLoaded();
    }

    private void Update()
    {
        if (sceneHandler is ISceneHandlerUpdatable updatable)
        {
            updatable.Update();
        }
    }

    // Scene Management Methods
    private void SceneManagerGetSceneLoaded()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetComponentsWhenSceneLoaded();
        CreateSceneHandler(scene);
        InitializeCurrentSceneHandler();
    }

    private void CreateSceneHandler(Scene scene)
    {
        DeactivateFruitsAndBombGameObject();
        switch (scene.name)
        {
            case "MainMenuScene":
                sceneHandler = null;
                SoundToBePlayedWhenMenuSceneStarts();
                break;
            case "MultiPlayerMenuScene":
                sceneHandler = null;
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
        sceneHandler?.Initialize();
    }

    // Game State Management Methods
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
        ShowGameover();
        sceneHandler?.GameOver();
    }

    public void RestartTheGame()
    {
        DeactivateFruitsAndBombGameObject();
        ResetGameIsOver();
        ResetIsGamePaused();
        ChangeTimeScale(1);
        ActivatedSpawnManager();
        if (sceneHandler is ISceneHandlerRestartable restartable)
        {
            restartable.RestartTheGame();
        }
        HideGameOver();
    }

    private void HideGameOver()
    {
        HandleGameScenePanel(panel => panel.HideGameOverPanel());
    }

    private void ShowGameover()
    {
        HandleGameScenePanel(panel => panel.ShowGameOverPanel());
        
    }

    // Spawn Management Methods
    private void ActivatedSpawnManager()
    {
        SpawnManager.Instance.gameObject?.SetActive(true);
    }

    private void DeactivetedSpawnManager()
    {
        SpawnManager.Instance.gameObject?.SetActive(false);
    }

    // UI and Panel Methods
    private void HandleGameScenePanel(System.Action<UIPanelHandler> panelAction)
    {
        if (sceneHandler is SinglePlayerGameSceneHandler)
        {
            panelAction(UIManager.Instance.singlePlayerPanelHandler);
        }
        else if (sceneHandler is MultiPlayerLivesGameSceneHandler || sceneHandler is MultiPlayerTimeGameSceneHandler)
        {
            panelAction(UIManager.Instance.multiPlayerPanelHandler);
        }
    }    
    // Fruit and Bomb Management
    private void DeactivateFruitsAndBombGameObject()
    {
        GameObject objectPool = GameObject.Find("ObjectPool");
        if (objectPool != null)
        {
            string[] tags = { "AppleFruit", "CoconutFruit", "OrangeFruit", "PearFruit", "WatermelonFruit", "Bomb" };

            foreach (string tag in tags)
            {   
                
                GameObject[] objectsToDeactivate = objectPool.GetComponentsInChildren<Transform>()
                                                 .Where(t => t.CompareTag(tag) && t.gameObject.activeSelf)
                                                 .Select(t => t.gameObject)
                                                 .ToArray();

                foreach (GameObject obj in objectsToDeactivate)
                {
                    obj.SetActive(false);
                }
            }
        }

    }
    public void OnFruitCut(int playerID)
    {
        if (sceneHandler is ISceneHandlerFruitCutUpdatable fruitCutUpdatable)
        {
            fruitCutUpdatable.FruitCutUpdate(playerID);
        }
    }

    // Pause and Resume Methods
    public void TogglePause()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        ChangeTimeScale(0);
        AudioManager.Instance.PauseAllSounds();
    }

    private void ResumeGame()
    {
        ChangeTimeScale(1);
        AudioManager.Instance.ResumeAllSounds();
        if (sceneHandler is ISceneHandlerResumable resumable)
        {
            resumable.ResumeTheGame();
        }
    }

    // Sound Management Methods
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

    // Scene Loading Methods
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

    // Utility Methods
    private void ChangeTimeScale(float timeScaleValue)
    {
        Time.timeScale = timeScaleValue;
    }

    private void ResetIsGamePaused()
    {
        isGamePaused = false;
    }

    private void ResetComponentsWhenSceneLoaded()
    {
        ResetIsGamePaused();
        ResetGameIsOver();
        ChangeTimeScale(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

