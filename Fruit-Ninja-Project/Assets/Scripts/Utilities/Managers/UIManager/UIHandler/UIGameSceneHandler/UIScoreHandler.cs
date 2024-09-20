using TMPro;

public class UIScoreHandler
{
    public TextMeshProUGUI firstPlayerScoreText;
    public TextMeshProUGUI secondPlayerScoreText;

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
    /*public void UpdateScoreText(int score)
    {
       scoreText.text = score.ToString();
    }*/
}
