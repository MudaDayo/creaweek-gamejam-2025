using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        audioManager?.PlaySound("LevelMusic");
    }

    public void StopMusic()
    {
        audioManager?.FadeOut("LevelMusic", 1f);
    }
}
