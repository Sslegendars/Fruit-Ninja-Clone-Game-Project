using UnityEngine.UI;

public class UIMultiPlayerMenuButtonHandler : UIButtonHandler
{
    public Button depentOnTimeButton;
    public Button depentOnLivesButton;
    public Button mainMenubutton;
    public void Initialize(Button depentOnTimeButton, Button depentOnLivesButton, Button mainMenubutton)
    {
        this.depentOnTimeButton = depentOnTimeButton;
        this.depentOnLivesButton = depentOnLivesButton;
        this.mainMenubutton = mainMenubutton;
        InitializeMultiPlayerMenuBottons();
    }
    private void SetDepentOnLivesButton()
    {
       SetButton(depentOnLivesButton, GameManager.Instance.LoadMultiPlayerDepentOnLivesGameScene);
    }
    private void SetDepentOnTimeButton()
    {
        SetButton(depentOnTimeButton, GameManager.Instance.LoadMultiPlayerDepentOnTimeGameScene);
    }
    private void SetMainMenuButton()
    {
        SetButton(mainMenubutton, GameManager.Instance.LoadMainMenuScene);
    }
    private void InitializeMultiPlayerMenuBottons()
    {
        SetDepentOnLivesButton();
        SetDepentOnTimeButton();
        SetMainMenuButton();
    }
}
