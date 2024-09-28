using UnityEngine;
using UnityEngine.UI;

public class ButtonIconChanger : MonoBehaviour
{   
    [SerializeField]
    private Image iconImage;
    [SerializeField]
    private Sprite newIcon;
    private Sprite originalIcon;
    private void Start()
    {
        originalIcon = iconImage.sprite;
        ChangeIcon();
    }
    private void OnEnable()
    {
        AudioManager.OnSoundStateChanged += ChangeIcon; 
    }
    private void OnDisable()
    {
        AudioManager.OnSoundStateChanged -= ChangeIcon; 
    }   
    public void ChangeIcon()
    {
        if (AudioManager.Instance.IsSoundOff)
        {
            iconImage.sprite = newIcon;
        }
        else
        {
            iconImage.sprite = originalIcon;
        }
    }
}
