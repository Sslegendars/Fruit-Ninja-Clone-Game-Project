using UnityEngine;
using UnityEngine.UI;
public class GameSceneUIInitializer : MonoBehaviour
{
    [Header("Pause Panel Settings")]
    [SerializeField]
    protected GameObject[] pausePanel;
    [SerializeField]
    protected GameObject gameOverPanel;
    [Header("UIButton Settings")]
    [SerializeField]
    private Button[] restartGameButton;
    [SerializeField]
    private Button[] loadPreviousScenebutton;
    [SerializeField]
    private Button[] pauseButton;
    [SerializeField]
    private Button[] soundOffButton;

    private void Start()
    {
        InitializeUIComponents();
    }
    protected virtual void InitializeUIComponents()
    {
        UIManager.Instance.gameSceneButtonHandler.Initialize(restartGameButton, loadPreviousScenebutton,pauseButton,soundOffButton);
        
    }
}
