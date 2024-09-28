using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerMenuSceneUIInitializer : MonoBehaviour
{   
    [SerializeField]
    private Button depentOnTimeButton;
    [SerializeField]
    private Button depentOnLivesButton;
    [SerializeField]
    private Button mainMenubutton;
    
    void Start()
    {
        UIManager.Instance.multiPlayerMenuButtonHandler.Initialize(depentOnTimeButton, depentOnLivesButton, mainMenubutton);
    }

   
}
