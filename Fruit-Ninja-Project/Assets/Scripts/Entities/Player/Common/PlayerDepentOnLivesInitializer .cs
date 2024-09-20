using UnityEngine;

public class PlayerDepentOnLivesInitializer : PlayerInitializer
{
    [Header("Player Injection")]
    public PlayerLives playerLives;
    protected PlayerControllerDepentOnLives playerControllerDepentOnLives;
    
    

    private void Awake()
    {
        InitializeComponents();
    }
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        playerControllerDepentOnLives = (PlayerControllerDepentOnLives)playerController;
        playerControllerDepentOnLives.PlayerLives = playerLives;        
        playerLives.PlayerID = playerID;
        
    }


}
