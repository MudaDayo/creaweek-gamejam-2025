using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Canvas endScreen;
    [SerializeField] private TextMeshProUGUI scoreText1, scoreText2, a, b, c;
    [SerializeField] private ScoreCalculation scoreCalculation;
    [Header("Name of game scene")]
    [SerializeField] private string sceneName;
    [Header("Breed names")]
    [SerializeField] private string 
        player1Breed, 
        player2Breed,
        player3Breed,
        player4Breed;

    private void Start()
    {
        endScreen.enabled = false;
        scoreCalculation = FindFirstObjectByType<ScoreCalculation>();
    }
    public void playAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void showEndScreen()
    {
        int winner = scoreCalculation.GetFirstPlayer();
        string player = "";
        switch (winner)
        {
            case 1:
                player = player1Breed;
                a.text = $"{player2Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().y)}%";
                b.text = $"{player3Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().z)}%";
                c.text = $"{player4Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().w)}%";
                break;
            case 2:
                a.text = $"{player1Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().x)}%";
                b.text = $"{player3Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().z)}%";
                c.text = $"{player4Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().w)}%";
                player = player2Breed;
                break;
            case 3:
                a.text = $"{player1Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().x)}%";
                b.text = $"{player2Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().y)}%";
                c.text = $"{player4Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().w)}%";
                player = player3Breed;
                break;
            case 4:
                a.text = $"{player1Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().x)}%";
                b.text = $"{player2Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().y)}%";
                c.text = $"{player3Breed} {Mathf.RoundToInt(scoreCalculation.GetPercents().z)}%";
                player = player4Breed;
                break;
        }

        endScreen.enabled = true;
        scoreText1.text = $"{player} {scoreCalculation.GetFirstPlayer()} is the MVPee";
        scoreText2.text = $"{Mathf.RoundToInt(scoreCalculation.GetHighestPercent())}%";

    }
}
