using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    protected int playerID;
    protected Blade _blade;

    public Blade Blade
    {
        get => _blade;
        set => _blade = value;
    }
    public int PlayerID
    {
        get => playerID;
        set => playerID = value;
    }
    private void Update()
    {   
        if(GameManager.Instance.GameIsOver != true)
        InputBehaviour();
    }

    protected virtual void HandleInput(Touch touch)
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

    protected abstract void InputBehaviour();
   
        
}



