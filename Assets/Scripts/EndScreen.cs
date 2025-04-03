using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Canvas endScreen;
    [SerializeField] private TextMeshProUGUI scoreText1, scoreText2;
    [SerializeField] private ScoreCalculation scoreCalculation;
    [Header("Name of game scene")]
    [SerializeField] private string sceneName;

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
        endScreen.enabled = true;
        scoreText1.text = $"Player {scoreCalculation.GetFirstPlayer()} is the MVPee";
        scoreText2.text = $"{Mathf.RoundToInt(scoreCalculation.GetHighestPercent())}%";
    }
}
