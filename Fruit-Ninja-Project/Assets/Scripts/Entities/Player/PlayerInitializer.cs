using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{   
    [Header("Player Injection")]
    public PlayerController playerController;
    public PlayerLives playerLives;
    public Blade _blade;
    public int playerID;
    [Header("Blade Injection")]
    public Camera mainCamera;
    public Collider bladeCollider;
    public TrailRenderer bladeTrail;

    private void Awake()
    {
        InitializeComponents();
    }
    private void InitializeComponents()
    {
        _blade.MainCamera = mainCamera;
        _blade.BladeCollider = bladeCollider;
        _blade.BladeTrail = bladeTrail;
        _blade.PlayerID = playerID;
        playerController.Blade = _blade;
        playerController.PlayerLives = playerLives;
        playerController.PlayerID = playerID;
        playerLives.PlayerID = playerID;
        
    }


}
