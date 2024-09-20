using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIButtonHandler
{
    public Button restartButton;
    public Button loadPreviousMenuSceneButton;    
    public Button mainMenuButton;
    public void Initialize(Button restartButton, Button loadPreviousMenuSceneButton, Button mainMenuButton)
    {
        this.restartButton = restartButton;
        this.loadPreviousMenuSceneButton = loadPreviousMenuSceneButton;        
        this.mainMenuButton = mainMenuButton;
        InitializeButton();
    }
    
    private void SetMainMenuButton()
    {          
        SetButton(mainMenuButton, GameManager.Instance.LoadMainMenuScene);
        //mainMenuButton.onClick.AddListener(GameManager.Instance.LoadMainMenuScene);
    }
    private void SetLoadPreviousSceneButton()
    {
        if (loadPreviousMenuSceneButton.tag == "MultiPlayerButton")
        {
            SetButton(loadPreviousMenuSceneButton, GameManager.Instance.LoadMultiPlayerMenuScene);
        }
        else if(loadPreviousMenuSceneButton.tag == "SinglePlayerButton")
        {
            SetButton(loadPreviousMenuSceneButton, GameManager.Instance.LoadMainMenuScene);
        }      
    }    
    public void SetRestartButton()
    {
        //SetButton(restartButton, GameManager.Instance.RestartTheGame);
        ButtonHelper.SetButton(restartButton, GameManager.Instance.RestartTheGame);
    }

    public void SetButton(Button button, UnityAction addListenerEvent)
    {
        button.onClick.AddListener(addListenerEvent);

    }
    public void InitializeButton()
    {
        SetMainMenuButton();
        SetLoadPreviousSceneButton();
        SetRestartButton();
    }
}
