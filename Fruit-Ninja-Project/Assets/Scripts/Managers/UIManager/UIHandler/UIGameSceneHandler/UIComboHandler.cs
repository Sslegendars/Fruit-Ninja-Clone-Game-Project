using TMPro;
using UnityEngine;
using System.Threading.Tasks;
public class UIComboHandler
{
    private TextMeshProUGUI[] comboText; 
    public void Initialize(TextMeshProUGUI[] comboText)
    {
        this.comboText = comboText;
    }
    public void ShowComboText(int comboCount, int playerID,Vector3 bladePosition)
    {
        switch (comboCount)
        {
            case 10:
                SetComboText(playerID,comboCount, Color.green);
                break;
            case 20:
                SetComboText(playerID,comboCount, Color.gray);
                break;
            case 30:
                SetComboText(playerID,comboCount, Color.yellow);
                break;
            case 40:
                SetComboText(playerID,comboCount, Color.cyan);
                break;
            case 50:
                SetComboText(playerID,comboCount, Color.red);
                break;
            case 60:
                SetComboText(playerID,comboCount, Color.white);
                break;
        }

        ComboTextPosition(playerID, comboText, bladePosition);
        ActivateComboText(playerID);
        DeactivateComboTextAfterDelay(playerID,1f);
    }
    private async void DeactivateComboTextAfterDelay( int playerID,float delayInSeconds)
    {
        await Task.Delay((int)(delayInSeconds * 1000));
        DeactivateComboText(playerID);
    }
    private void SetComboText(int playerID,int comboCount, Color color)
    {
        SetComboTextColor(playerID,color);
        SetComboTextStringValue(playerID,comboCount);        
    }
    private void ActivateComboText(int playerID)
    {
        comboText[playerID].gameObject.SetActive(true);       
    }
    public void DeactivateComboText(int playerID)
    {
        comboText[playerID].gameObject.SetActive(false);        
    }
    private void ComboTextPosition(int playerID,TextMeshProUGUI[] comboText, Vector3 bladePosition)
    {
        Vector3 screenPosition = bladePosition;
        screenPosition.z = bladePosition.z + -2.5f;
        comboText[playerID].transform.position = screenPosition;
    }
    private void SetComboTextColor(int playerID,Color color)
    {
        comboText[playerID].color = color;
    }
    private void SetComboTextStringValue(int playerID,int comboCount)
    {
        comboText[playerID].text = comboCount.ToString() + "\nPOINTS";
    }
}
