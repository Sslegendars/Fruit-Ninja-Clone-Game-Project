using UnityEngine;
public class SinglePlayerController : PlayerControllerDepentOnLives
{
    protected override void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            HandleInput(touch);
        }
    }


}
