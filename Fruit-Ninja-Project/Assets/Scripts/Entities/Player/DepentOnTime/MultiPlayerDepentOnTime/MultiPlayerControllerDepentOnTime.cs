
public class MultiPlayerControllerDepentOnTime : PlayerController
{
    private MultiPlayerTouchHandler multiPlayerTouchHandler;
    private void Start()
    {
        CallMultiPlayerTouchHandler();
    }   
    protected override void InputBehaviour()
    {         
        HandleTouchInput();
    }
    private void HandleTouchInput()
    {   
        multiPlayerTouchHandler.CheckHandleInput(HandleInput, playerID);
    }
    private void CallMultiPlayerTouchHandler()
    {
        multiPlayerTouchHandler = new MultiPlayerTouchHandler();
    }
}
