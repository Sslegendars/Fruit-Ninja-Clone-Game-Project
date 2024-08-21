using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{   
    
    public int Lives { get; private set; }

    private void Start()
    {
        UpdateLivesWhenGameStarted();
    }
    public void DecreaseLife()
    {   
        if(Lives > 0)
        {
            LoseLife();
        }        
        else
        {
            GameManager.Instance.GameOver();
        }
    }
    private void LoseLife()
    {         
        Lives--;
        UIManager.Instance.UpdateLivesText(Lives);       
    }

    private void UpdateLivesWhenGameStarted()
    {
        Lives = 100;
        UIManager.Instance.UpdateLivesText(Lives);
    }
}
