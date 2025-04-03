using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Canvas endScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
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
        scoreText.text = "Score: " + scoreCalculation.GetPercents();
    }
}
