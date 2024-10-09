
public abstract class PlayerControllerDepentOnLives : PlayerController
{
    protected PlayerLives playerLives;
    public PlayerLives PlayerLives
    {
        get => playerLives;
        set => playerLives = value;
    }
    protected override void InputBehaviour()
    {
        if (playerLives.Lives > 0)
        {
            HandleTouchInput();
        }
    }

    protected abstract void HandleTouchInput();
}
