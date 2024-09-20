using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ButtonHelper 
{
    public static void SetButton(UnityEngine.UI.Button button, UnityEngine.Events.UnityAction addListenerEvent)
    {
        button.onClick.AddListener(addListenerEvent);

    }
}
