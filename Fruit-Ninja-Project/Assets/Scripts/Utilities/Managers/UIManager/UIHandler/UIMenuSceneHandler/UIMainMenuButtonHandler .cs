using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIMainMenuButtonHandler 
{
    public Button singlePlayerGameSceneButton;
    public Button multiPlayerMenuSceneButton;

    public void Intialize(Button singlePlayerGameSceneButton, Button multiPlayerMenuSceneButton)
    {
        this.singlePlayerGameSceneButton = singlePlayerGameSceneButton;
        this.multiPlayerMenuSceneButton = multiPlayerMenuSceneButton;
        InitializeMainMenuButton();
    }
    
    private void SetSinglePlayerButton()
    {
        ButtonHelper.SetButton(singlePlayerGameSceneButton, GameManager.Instance.LoadSinglePlayerGameScene);        
    }
    private void SetMultiPlayerButton()
    {
        ButtonHelper.SetButton(multiPlayerMenuSceneButton, GameManager.Instance.LoadMultiPlayerMenuScene);
    }
    private void InitializeMainMenuButton()
    {
        SetSinglePlayerButton();
        SetMultiPlayerButton();
    }
}
