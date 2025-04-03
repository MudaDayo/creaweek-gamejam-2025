using UnityEngine;

public class UICrownManager : MonoBehaviour
{
    [SerializeField] private ScoreCalculation scoreCalculation;
    [SerializeField] private GameObject a, b, c, d;

    private void Start()
    {
        scoreCalculation = FindFirstObjectByType<ScoreCalculation>();
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(false);
    }
    private void Update()
    {
        ShowCrown();
    }
    public void ShowCrown()
    {
        int winner = scoreCalculation.GetFirstPlayer();
        switch (winner)
        {
            case 1:
                a.SetActive(true);
                break;
            case 2:
                b.SetActive(true);
                break;
            case 3:
                c.SetActive(true);
                break;
            case 4:
                d.SetActive(true);
                break;
        }
    }
}
