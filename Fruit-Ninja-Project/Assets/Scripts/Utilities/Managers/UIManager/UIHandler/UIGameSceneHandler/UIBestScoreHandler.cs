using TMPro;

public class UIBestScoreHandler
{
    public TextMeshProUGUI bestScoreText;

    public void Initialize(TextMeshProUGUI bestScoreText)
    {
        this.bestScoreText = bestScoreText;       
    }
    public void ShowBestScore(int bestScore)
    {
        bestScoreText.text = "BEST SCORE\n" + bestScore.ToString();
    }
}
