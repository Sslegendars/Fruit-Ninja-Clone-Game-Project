using UnityEngine.UI;

public class UIMultiPlayerMenuButtonHandler
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
        ButtonHelper.SetButton(depentOnLivesButton, GameManager.Instance.LoadMultiPlayerDepentOnLivesGameScene);
    }
    private void SetDepentOnTimeButton()
    {
        ButtonHelper.SetButton(depentOnTimeButton, GameManager.Instance.LoadMultiPlayerDepentOnTimeGameScene);
    }
    private void SetMainMenuButton()
    {
        ButtonHelper.SetButton(mainMenubutton, GameManager.Instance.LoadMainMenuScene);
    }
    private void InitializeMultiPlayerMenuBottons()
    {
        SetDepentOnLivesButton();
        SetDepentOnTimeButton();
        SetMainMenuButton();
    }
}
