using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDepentOnTimeInitializer : PlayerInitializer
{
    protected MultiPlayerControllerDepentOnTime multiPlayerControllerDepentOnTime;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        multiPlayerControllerDepentOnTime = (MultiPlayerControllerDepentOnTime)playerController;
    }
}
