using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerController : PlayerController
{
    private void Update()
    {
        InputBehaviourCondition();
    }

    private void InputBehaviourCondition()
    {
        if (playerLives.Lives > 0)
        {
            CheckHandleInput();
        }
    }
    private void CheckHandleInput()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            HandleInput(touch);
        }
    }    
}
