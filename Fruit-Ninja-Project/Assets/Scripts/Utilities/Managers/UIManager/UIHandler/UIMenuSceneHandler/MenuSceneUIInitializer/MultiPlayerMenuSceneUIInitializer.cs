using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerMenuSceneUIInitializer : MonoBehaviour
{
    public Button depentOnTimeButton;
    public Button depentOnLivesButton;
    public Button mainMenubutton;
    
    void Start()
    {
        UIManager.Instance.multiPlayerMenuButtonHandler.Initialize(depentOnTimeButton, depentOnLivesButton, mainMenubutton);
    }

   
}
