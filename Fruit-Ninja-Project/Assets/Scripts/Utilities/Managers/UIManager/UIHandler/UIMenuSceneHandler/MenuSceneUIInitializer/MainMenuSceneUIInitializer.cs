using UnityEngine;
using UnityEngine.UI;

public class MainMenuSceneUIInitializer : MonoBehaviour
{
    public Button singlePlayerGameSceneButton;
    public Button multiPlayerGameSceneButton;

    private void Start()
    {
        UIManager.Instance.mainMenuButtonHandler.Intialize(singlePlayerGameSceneButton, multiPlayerGameSceneButton);
    }
}
