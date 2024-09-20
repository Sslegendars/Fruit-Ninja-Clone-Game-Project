using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerTouchHandler 
{
    public void CheckHandleInput(System.Action<Touch> HandleInput, int playerID)
    {
        // Dokunma olaylar�n� ba��ms�z olarak y�net
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Dokunma olay�n� uygun oyuncuya y�nlendir
            if (IsTouchForThisPlayer(touch, playerID))
            {
                HandleInput(touch);
            }
        }
    }

    private bool IsTouchForThisPlayer(Touch touch, int playerID)
    {
        Vector2 touchPosition = touch.position;

        // Ekran� iki b�lgeye ay�r�n: sol ve sa�
        Rect player1Area = new Rect(0, 0, Screen.width / 2, Screen.height);
        Rect player2Area = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);

        if (playerID == 0 && player1Area.Contains(touchPosition))
        {
            return true;
        }
        else if (playerID == 1 && player2Area.Contains(touchPosition))
        {
            return true;
        }
        return false;
    }
}
