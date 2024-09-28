
public class MultiPlayerControllerDepentOnTime : PlayerController
{
    private MultiPlayerTouchHandler multiPlayerTouchHandler;
    private void Start()
    {
        CallMultiPlayerTouchHandler();
    }
    private void Update()
    {
        InputBehaviourContidion();
    }
    private void InputBehaviourContidion()
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
