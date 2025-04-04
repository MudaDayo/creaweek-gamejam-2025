using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTime = 10f; // Set in Inspector
    private float timeRemaining;
    private bool timerRunning = true;

    [Header("UI Elements")]
    public TextMeshProUGUI timerText; // Assign in Inspector
    public Canvas gameOverCanvas; // Assign in Inspector

    void Start()
    {
        timeRemaining = startTime;
        gameOverCanvas.enabled = false;
    }

    void Update()
    {
        if (timerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;
            gameOverCanvas.GetComponent<EndScreen>().showEndScreen();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}