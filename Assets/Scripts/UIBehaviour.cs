using Unity.VisualScripting;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] private Canvas start, credits, controls;
    [SerializeField] private string sceneName;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void ShowCredits()
    {
        start.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }
    public void ShowControls()
    {
        start.gameObject.SetActive(false);
        controls.gameObject.SetActive(true);
    }
    public void Back()
    {
        start.gameObject.SetActive(true);
        credits.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
