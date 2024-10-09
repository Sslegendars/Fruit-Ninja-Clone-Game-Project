
public class MultiPlayerControllerDepentOnLives : PlayerControllerDepentOnLives
{
    private MultiPlayerTouchHandler multiPlayerTouchHandler;
    private void Start()
    {
        CallMultiPlayerTouchHandler();
    }
    protected override void HandleTouchInput()
    {
        if (multiPlayerTouchHandler != null)
        {
            multiPlayerTouchHandler.CheckHandleInput(HandleInput, playerID);
        }
    }

    private void CallMultiPlayerTouchHandler()
    {
        multiPlayerTouchHandler = new MultiPlayerTouchHandler();
    }

}
