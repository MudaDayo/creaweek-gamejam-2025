using UnityEngine;

public class BarkScript : MonoBehaviour
{
    private AudioManager audioManager;

    public int playerID = 1;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        audioManager?.PlaySound("LevelMusic");
    }
    void Update()
    {
        if (playerID == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioManager?.PlaySound("Bark1");
            }
        }

        else
        {
            // east gamepad button pressed
            if (Input.GetKeyDown("joystick button 1"))
            {
                audioManager?.PlaySound("Bark" + playerID);
            }

        }
    }
}
