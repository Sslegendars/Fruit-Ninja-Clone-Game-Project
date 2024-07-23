using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Blade _blade;
    private PlayerLives playerLives;

    public Blade Blade
    {
        get => _blade;
        set
        {
            _blade = value;            
        }
    }
    public PlayerLives PlayerLives
    {
        get => playerLives;
        set
        {
            playerLives = value;
        }
    }
    private void Update()
    {
        InputBehaviourCondition();
        
    }
    private void InputBehaviourCondition()
    {
        if (playerLives.Lives > 0)
        {
            HandleInput();
        }
    }
    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _blade.StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _blade.StopSlicing();
        }
        else if (_blade.Slicing)
        {
            _blade.ContinueSlicing();
        }
    }
}
