using UnityEngine;
public class PlayerLives : MonoBehaviour
{   
    [HideInInspector]
    public int playerID;
    
    public int Lives { get; private set; }
    public int PlayerID
    {
        get => playerID;
        set => playerID = value;
    }
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
        UIManager.Instance.livesHandler.UpdateLivesText(playerID,Lives);       
    }

    private void UpdateLivesWhenGameStarted()
    {
        Lives = 100;
        UIManager.Instance.livesHandler.UpdateLivesText(playerID,Lives);
    }
    public int Zerolives()
    {
        return Lives = 0;
    }
    public void ResetLives()
    {
        UpdateLivesWhenGameStarted();
    }
}
