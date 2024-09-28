using UnityEngine.SceneManagement;
public class UIManager : MonoSingleton<UIManager>
{
    public UIBestScoreHandler bestScoreHandler;
    public UIComboHandler comboHandler;
    public UILivesHandler livesHandler;
    public UIScoreHandler scoreHandler;        
    public UITimerHandler timerHandler;

    // ButtonHandler
    public UIGameSceneButtonHandler gameSceneButtonHandler;
    public UIMainMenuButtonHandler mainMenuButtonHandler;
    public UIMultiPlayerMenuButtonHandler multiPlayerMenuButtonHandler;

    // Players panels handler
    public UISinglePlayerPanelHandler singlePlayerPanelHandler;
    public UIMultiPlayerPanelHandler multiPlayerPanelHandler;


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
                CallSinglePlayerPanelHandler();
                CallBestScoreUIHandler();
                CallComboUIHandler();
                CallLivesUIHandler();
                CallScoreUIHandler();
                CallUIButtonHandler();                              
                break;
            case "MultiPlayerDepentOnLivesGameScene":
                MultiPlayerMenuSceneElementIsNull();
                CallLivesUIHandler();
                CallMultiPlayerPanelHandler();
                CallUIButtonHandler();              
                break;
            case "MultiPlayerDepentOnTimeGameScene":
                MultiPlayerMenuSceneElementIsNull();
                CallTimerUIHandler();
                CallComboUIHandler();
                CallScoreUIHandler();                
                CallUIButtonHandler();
                CallMultiPlayerPanelHandler();
                break;
            default:
                break;
        }
    }     
    private void CallMultiPlayerPanelHandler()
    {
        multiPlayerPanelHandler = new UIMultiPlayerPanelHandler();        
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
    private void CallSinglePlayerPanelHandler()
    {
        singlePlayerPanelHandler = new UISinglePlayerPanelHandler();
        
        
    }
    private void GameSceneElementsAreNull()
    {   
        ResetUIElements
        (
            () => bestScoreHandler = null,
            () => comboHandler = null,
            () => livesHandler = null,
            () => scoreHandler = null,
            () => multiPlayerPanelHandler = null,
            () => gameSceneButtonHandler = null,
            () => timerHandler = null,
            () => singlePlayerPanelHandler = null
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
            resetAction.Invoke(); 
        }
    }

}
