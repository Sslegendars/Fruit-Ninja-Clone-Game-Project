using UnityEngine;
public class PlayerInitializer : MonoBehaviour
{
    [Header("Player Injection")]
    [SerializeField]
    protected PlayerController playerController;
    [SerializeField]
    protected int playerID;
    [SerializeField]
    private Blade _blade;    
    [Header("Blade Injection")]
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Collider bladeCollider;
    [SerializeField]
    private TrailRenderer bladeTrail;

    private void Awake()
    {
        InitializeComponents();
    }
    protected virtual void InitializeComponents()
    {
        _blade.MainCamera = mainCamera;
        _blade.BladeCollider = bladeCollider;
        _blade.BladeTrail = bladeTrail;
        _blade.PlayerID = playerID;
        playerController.Blade = _blade;
        playerController.PlayerID = playerID;
       

    }
}
