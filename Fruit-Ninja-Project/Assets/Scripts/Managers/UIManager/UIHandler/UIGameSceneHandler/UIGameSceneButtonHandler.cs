using UnityEngine.UI;
public class UIGameSceneButtonHandler : UIButtonHandler
{
    
    private Button[] restartButton;
    private Button[] loadPreviousMenuSceneButton;    
    private Button[] pauseButton;
    private Button[] soundOffButton;
    
    public void Initialize(Button[] restartButton, Button[] loadPreviousMenuSceneButton,Button[] pauseButton, Button[] soundOffButton)
    {
        this.restartButton = restartButton;
        this.loadPreviousMenuSceneButton = loadPreviousMenuSceneButton;        
        this.pauseButton = pauseButton;
        this.soundOffButton = soundOffButton;
        InitializeButton();
    }   
    private void SetLoadPreviousSceneButton()
    {   
        foreach(var loadPreviousMenuSceneButton in loadPreviousMenuSceneButton)
        {
            if (loadPreviousMenuSceneButton.tag == "MultiPlayerButton")
            {
                SetButton(loadPreviousMenuSceneButton, GameManager.Instance.LoadMultiPlayerMenuScene);
            }
            else if (loadPreviousMenuSceneButton.tag == "SinglePlayerButton")
            {
                SetButton(loadPreviousMenuSceneButton, GameManager.Instance.LoadMainMenuScene);
            }
        }
             
    }      
    private void SetRestartButton()
    {   
        foreach(var restartButton in restartButton)
        {
            SetButton(restartButton, GameManager.Instance.RestartTheGame);
        }
        
    }    
    private void SetPauseButton()
    {
        foreach(var pauseButton in pauseButton)
        {
            SetButton(pauseButton, GameManager.Instance.TogglePause);            
        }
    }
    private void SetSoundOffButton()
    {
        foreach (var soundOffButton in soundOffButton)
        {
            SetButton(soundOffButton, AudioManager.Instance.ToggleSoundOff);            
        }
    }

    public void InitializeButton()
    {
        SetLoadPreviousSceneButton();
        SetRestartButton();
        SetPauseButton();
        SetSoundOffButton();
    }
}
