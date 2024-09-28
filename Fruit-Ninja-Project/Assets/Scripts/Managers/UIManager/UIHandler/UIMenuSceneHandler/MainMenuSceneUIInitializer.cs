using UnityEngine;
using UnityEngine.UI;

public class MainMenuSceneUIInitializer : MonoBehaviour
{   
    [SerializeField]
    private Button singlePlayerGameSceneButton;
    [SerializeField]
    private Button multiPlayerGameSceneButton;

    private void Start()
    {
        UIManager.Instance.mainMenuButtonHandler.Intialize(singlePlayerGameSceneButton, multiPlayerGameSceneButton);
    }
}
