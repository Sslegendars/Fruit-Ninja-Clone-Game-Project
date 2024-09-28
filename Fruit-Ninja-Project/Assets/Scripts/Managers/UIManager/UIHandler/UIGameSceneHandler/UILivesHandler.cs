using TMPro;
public class UILivesHandler
{
    private TextMeshProUGUI firstPlayerLivesText;
    private TextMeshProUGUI secondPlayerLivesText;

    public void Initialize(TextMeshProUGUI firstPlayerLivesText, TextMeshProUGUI secondPlayerLivesText)
    {
        this.firstPlayerLivesText = firstPlayerLivesText;
        this.secondPlayerLivesText = secondPlayerLivesText;
    }
    public void UpdateLivesText(int playerID, int lives)
    {
        if (playerID == 0)
            firstPlayerLivesText.text = LivesTextString(lives);
        else if (playerID == 1)
            secondPlayerLivesText.text = LivesTextString(lives);
    }
    private string LivesTextString(int playerLives)
    {
        return "Lives: " + playerLives;
    }
}
