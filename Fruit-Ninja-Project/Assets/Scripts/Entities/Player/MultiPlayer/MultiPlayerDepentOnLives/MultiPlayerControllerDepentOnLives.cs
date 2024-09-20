using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerControllerDepentOnLives : PlayerControllerDepentOnLives
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
        if(playerLives.Lives > 0)
        {
            HandleTouchInput();
        }
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
