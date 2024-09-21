using UnityEngine.SceneManagement;
public class UIManager : MonoSingleton<UIManager>
{
    public UIBestScoreHandler bestScoreHandler;
    public UIComboHandler comboHandler;
    public UILivesHandler livesHandler;
    public UIScoreHandler scoreHandler;
    public UIHandlerMultiPlayer multiPlayerHandler;
    public UIGameSceneButtonHandler gameSceneButtonHandler;
    public UIGameOverHandler gameOverHandler;
    public UITimerHandler timerHandler;
    public UIMainMenuButtonHandler mainMenuButtonHandler;
    public UIMultiPlayerMenuButtonHandler multiPlayerMenuButtonHandler;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        SceneLoaded();     
    } 
    public void SceneLoaded()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CreateInterfaceHandler(scene);
        
    }
    private void CreateInterfaceHandler(Scene scene)
    {    
        switch (scene.name)
        {               
            case "MainMenuScene":
                GameSceneElementsAreNull();
                MultiPlayerMenuSceneElementIsNull();
                CallUIMenuButtonHandler();
                break;
            case "MultiPlayerMenuScene":
                GameSceneElementsAreNull();
                MainMenuSceneElementIsNull();
                CallMultiPlayerMenubuttonHandler();
                break;
            case "SinglePlayerGameScene":
                MainMenuSceneElementIsNull();
                CallGameOverUIHandler();
                CallBestScoreUIHandler();
                CallComboUIHandler();
                CallLivesUIHandler();
                CallScoreUIHandler();
                CallUIButtonHandler();                              
                break;
            case "MultiPlayerDepentOnLivesGameScene":
                MultiPlayerMenuSceneElementIsNull();
                CallGameOverUIHandler();
                CallLivesUIHandler();
                CallUIHandlerMultiPlayer();
                CallUIButtonHandler();              
                break;
            case "MultiPlayerDepentOnTimeGameScene":
                MultiPlayerMenuSceneElementIsNull();
                CallGameOverUIHandler();
                CallTimerUIHandler();
                CallComboUIHandler();
                CallScoreUIHandler();                
                CallUIButtonHandler();
                CallUIHandlerMultiPlayer();
                break;
            default:
                break;
        }
    }     
    private void CallUIHandlerMultiPlayer()
    {
        multiPlayerHandler = new UIHandlerMultiPlayer();        
    }
    private void CallScoreUIHandler()
    {
        scoreHandler = new UIScoreHandler();
    }
    private void CallComboUIHandler()
    {
        comboHandler = new UIComboHandler();
    }
    private void CallBestScoreUIHandler()
    {
        bestScoreHandler = new UIBestScoreHandler();
    }
    private void CallLivesUIHandler()
    {
        livesHandler = new UILivesHandler();
    }
    private void CallUIButtonHandler()
    {
        gameSceneButtonHandler = new UIGameSceneButtonHandler();
    }
    private void CallGameOverUIHandler()
    {
        gameOverHandler = new UIGameOverHandler();
    }
    private void CallTimerUIHandler()
    {
        timerHandler = new UITimerHandler();
    }
    private void CallUIMenuButtonHandler()
    {
        mainMenuButtonHandler = new UIMainMenuButtonHandler();
    }
    private void CallMultiPlayerMenubuttonHandler()
    {
        multiPlayerMenuButtonHandler = new UIMultiPlayerMenuButtonHandler();
    }
    private void GameSceneElementsAreNull()
    {   
        ResetUIElements
        (
            () => bestScoreHandler = null,
            () => comboHandler = null,
            () => livesHandler = null,
            () => scoreHandler = null,
            () => multiPlayerHandler = null,
            () => gameSceneButtonHandler = null,
            () => gameOverHandler = null,
            () => timerHandler = null
        );
    }
    private void MainMenuSceneElementIsNull()
    {   
        ResetUIElements
        (
           () => mainMenuButtonHandler = null
        );
        
    }
    private void MultiPlayerMenuSceneElementIsNull()
    {
        ResetUIElements
            (
                () => multiPlayerMenuButtonHandler = null
            );
    }
    private void ResetUIElements(params System.Action[] resetActions)
    {
        foreach (var resetAction in resetActions)
        {
            resetAction.Invoke(); // Her bir sýfýrlama iþlemini gerçekleþtir
        }
    }

}
