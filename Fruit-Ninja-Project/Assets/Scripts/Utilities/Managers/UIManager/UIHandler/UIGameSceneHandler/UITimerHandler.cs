using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimerHandler
{
    public TextMeshProUGUI[] playersTimeText;
    public void Initialize(TextMeshProUGUI[] playersTimeText)
    {
        this.playersTimeText = playersTimeText;
    }
    public void UpdatePlayersTimeText(float remainingTime)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        playersTimeText[0].text = string.Format("{0:00}:{1:00}", minutes, seconds);
        playersTimeText[1].text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (remainingTime == 9f)
        {
            ChangePlayersTimeTextColor(Color.red);
        }
    }
    private void ChangePlayersTimeTextColor(Color color)
    {
        playersTimeText[0].color = color;
        playersTimeText[1].color = color;
    }
}
