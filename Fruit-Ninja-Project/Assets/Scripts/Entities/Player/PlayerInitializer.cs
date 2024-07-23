using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{   
    [Header("Player Controller Injection")]
    public PlayerController playerController;
    public PlayerLives playerLives;
    public Blade _blade;    
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
        playerController.Blade = _blade;
        playerController.PlayerLives = playerLives;
        _blade.MainCamera = mainCamera;
        _blade.BladeCollider = bladeCollider;
        _blade.BladeTrail = bladeTrail;
    }


}
