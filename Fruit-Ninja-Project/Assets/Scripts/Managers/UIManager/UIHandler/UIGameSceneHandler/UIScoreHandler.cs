using TMPro;
public class UIScoreHandler
{
    private TextMeshProUGUI firstPlayerScoreText;
    private TextMeshProUGUI secondPlayerScoreText;

    public void Initialize(TextMeshProUGUI firstPlayerScoreText, TextMeshProUGUI secondPlayerScoreText)
    {
        this.firstPlayerScoreText = firstPlayerScoreText;
        this.secondPlayerScoreText = secondPlayerScoreText;
    }
    public void FirstPlayerUpdateScoreText(int firstPlayerScore)
    {
        firstPlayerScoreText.text = firstPlayerScore.ToString();
    }
    public void SecondPlayerUpdateScoreText(int secondPlayerScore )
    {
        secondPlayerScoreText.text = secondPlayerScore.ToString();
    }    
}
