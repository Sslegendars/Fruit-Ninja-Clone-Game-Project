using UnityEngine;
using UnityEngine.UI;

public class GameSceneUIInitializer : MonoBehaviour
{
    public GameObject gameOverPanel;
    [Header("UIButton Settings")]
    public Button restartGameButton;
    public Button loadPreviousScenebutton;
    public Button mainMenubutton;
    

    private void Start()
    {
        InitializeUIComponents();
    }
    protected virtual void InitializeUIComponents()
    {
        UIManager.Instance.gameOverHandler.Intialize(gameOverPanel);
        UIManager.Instance.buttonHandler.Initialize(restartGameButton, loadPreviousScenebutton, mainMenubutton);
        
    }
}
