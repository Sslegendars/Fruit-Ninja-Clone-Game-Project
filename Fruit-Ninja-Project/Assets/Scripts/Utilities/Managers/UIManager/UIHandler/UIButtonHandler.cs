public class UIButtonHandler
{
    protected void SetButton(UnityEngine.UI.Button button, UnityEngine.Events.UnityAction addListenerEvent)
    {
        button.onClick.AddListener(addListenerEvent);
        button.onClick.AddListener(GameManager.Instance.PlayButtonSound);
    }
    
}

