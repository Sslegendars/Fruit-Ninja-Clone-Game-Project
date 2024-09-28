using UnityEngine;
using TMPro;
public class UITimerHandler
{
    private TextMeshProUGUI[] playersTimeText;
    private bool hasChangedColor = false;
    public void Initialize(TextMeshProUGUI[] playersTimeText)
    {
        this.playersTimeText = playersTimeText;
    }
    public void UpdatePlayersTimeText(float remainingTime)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        foreach (TextMeshProUGUI playerTimeText in playersTimeText)
        {
            playerTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        
        if (remainingTime <= 9f && !hasChangedColor)
        {
            ChangePlayersTimeTextColor(Color.red);
            hasChangedColor = true; 
        }
        else if (remainingTime > 9f && hasChangedColor)
        {
            ChangePlayersTimeTextColor(Color.yellow);
            hasChangedColor = false; 
        }
    }

    private void ChangePlayersTimeTextColor(Color color)
    {
        foreach (TextMeshProUGUI playerTimeText in playersTimeText)
        {
            playerTimeText.color = color;
        }
    }

}
