using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* public int playerID;
     private Blade _blade;
     private PlayerLives playerLives;
     public int touchNumber;

     public Blade Blade
     {
         get => _blade;
         set
         {
             _blade = value;
         }
     }
     public PlayerLives PlayerLives
     {
         get => playerLives;
         set
         {
             playerLives = value;
         }
     }

     private void Update()
     {
         InputBehaviourCondition();
     }

     private void InputBehaviourCondition()
     {
         if (playerLives.Lives > 0)
         {
             HandleInput();
         }
     }

     private void HandleInput()
     {
         for (int i = 0; i < Input.touchCount; i++)
         {
             Touch touch = Input.GetTouch(i);

             CheckTouchInput(touch);
         }
     }

     private void CheckTouchInput(Touch touch)
     {
         Vector2 touchPosition = touch.position;

         // Ekraný iki bölgeye ayýrýn: sol ve sað
         Rect player1Area = new Rect(0, 0, Screen.width / 2, Screen.height);
         Rect player2Area = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);

         if (playerID == 0 && player1Area.Contains(touchPosition))
         {
             Debug.Log("player1 touching");
             HandleBladeInput(touch);
         }
         else if (playerID == 1 && player2Area.Contains(touchPosition))
         {
             Debug.Log("player2 touching");
             HandleBladeInput(touch);
         }
     }

     private void HandleBladeInput(Touch touch)
     {
         if (touch.phase == TouchPhase.Began)
         {
             _blade.StartSlicing();
         }
         else if (touch.phase == TouchPhase.Ended)
         {
             _blade.StopSlicing();
         }
         else if (_blade.Slicing && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
         {
             _blade.ContinueSlicing();
         }
     }*/
    protected int playerID;
    protected Blade _blade;
    protected PlayerLives playerLives;

    public Blade Blade
    {
        get => _blade;
        set => _blade = value;
    }

    public PlayerLives PlayerLives
    {
        get => playerLives;
        set => playerLives = value;
    } 
    public int PlayerID
    {
        get => playerID;
        set => playerID = value;
    }
    protected void HandleInput(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            _blade.StartSlicing(touch.position);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            _blade.StopSlicing();
        }
        else if (_blade.Slicing && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
        {
            _blade.ContinueSlicing(touch.position);
        }
    }
}
