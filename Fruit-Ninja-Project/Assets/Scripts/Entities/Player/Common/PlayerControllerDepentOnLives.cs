using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDepentOnLives : PlayerController
{
    protected PlayerLives playerLives;
    public PlayerLives PlayerLives
    {
        get => playerLives;
        set => playerLives = value;
    }
    

}
