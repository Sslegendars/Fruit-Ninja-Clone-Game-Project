using UnityEngine.UI;

public class UIMainMenuButtonHandler : UIButtonHandler
{
    private Button singlePlayerGameSceneButton;
    private Button multiPlayerMenuSceneButton;
    public void Intialize(Button singlePlayerGameSceneButton, Button multiPlayerMenuSceneButton)
    {
        this.singlePlayerGameSceneButton = singlePlayerGameSceneButton;
        this.multiPlayerMenuSceneButton = multiPlayerMenuSceneButton;
        InitializeMainMenuButton();
    }    
    private void SetSinglePlayerButton()
    {
        SetButton(singlePlayerGameSceneButton, GameManager.Instance.LoadSinglePlayerGameScene);                
    }
    private void SetMultiPlayerButton()
    {
        SetButton(multiPlayerMenuSceneButton, GameManager.Instance.LoadMultiPlayerMenuScene);        
    }
    private void InitializeMainMenuButton()
    {
        SetSinglePlayerButton();
        SetMultiPlayerButton();
    }
}
