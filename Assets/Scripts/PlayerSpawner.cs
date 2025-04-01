using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject prefab0; // Assign the first prefab in the Inspector
    public GameObject prefab1; // Assign the first prefab in the Inspector
    public GameObject prefab2; // Assign the second prefab in the Inspector
    public GameObject prefab3; // Assign the third prefab in the Inspector
    public GameObject prefab4; // Assign the fourth prefab in the Inspector
    public Transform spawnPoint1; // Assign the first spawn point in the Inspector
    public Transform spawnPoint2; // Assign the second spawn point in the Inspector
    public Transform spawnPoint3; // Assign the third spawn point in the Inspector
    public Transform spawnPoint4; // Assign the fourth spawn point in the Inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReadOnlyArray<Gamepad> gamepads = Gamepad.all;

        if (gamepads.Count == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(prefab1, spawnPoint1.position, spawnPoint1.rotation);
            }
            Debug.Log("No gamepads found, 1 min");
            return;
        }

        PlayerInput.Instantiate(prefab0, playerIndex: 0, controlScheme: "Gamepad");

        if (gamepads.Count > 0)
        {
            PlayerInput p1 = PlayerInput.Instantiate(prefab1, playerIndex: 1, controlScheme: "Gamepad", pairWithDevice: gamepads[0]);
            p1.transform.position = spawnPoint1.position;
            p1.transform.rotation = spawnPoint1.rotation;
        }
        PlayerInput p2;
        if (gamepads.Count > 1)
        {
            p2 = PlayerInput.Instantiate(prefab2, playerIndex: 2, controlScheme: "Gamepad", pairWithDevice: gamepads[1]);
            p2.transform.position = spawnPoint2.position;
            p2.transform.rotation = spawnPoint2.rotation;
        }
        else
        {
            p2 = PlayerInput.Instantiate(prefab2, controlScheme: "KeyboardMouse");
            p2.transform.position = spawnPoint2.position;
            p2.transform.rotation = spawnPoint2.rotation;
        }

        // Add Player 3
        PlayerInput p3;
        if (gamepads.Count > 2)
        {
            p3 = PlayerInput.Instantiate(prefab1, playerIndex: 3, controlScheme: "Gamepad", pairWithDevice: gamepads[2]);
            p3.transform.position = spawnPoint1.position + Vector3.right * 2; // Adjust position for Player 3
            p3.transform.rotation = spawnPoint1.rotation;
        }
        else
        {
            p3 = PlayerInput.Instantiate(prefab1, controlScheme: "KeyboardMouse");
            p3.transform.position = spawnPoint1.position + Vector3.right * 2; // Adjust position for Player 3
            p3.transform.rotation = spawnPoint1.rotation;
        }

        // Add Player 4
        PlayerInput p4;
        if (gamepads.Count > 3)
        {
            p4 = PlayerInput.Instantiate(prefab2, playerIndex: 4, controlScheme: "Gamepad", pairWithDevice: gamepads[3]);
            p4.transform.position = spawnPoint2.position + Vector3.left * 2; // Adjust position for Player 4
            p4.transform.rotation = spawnPoint2.rotation;
        }
        else
        {
            p4 = PlayerInput.Instantiate(prefab2, controlScheme: "KeyboardMouse");
            p4.transform.position = spawnPoint2.position + Vector3.left * 2; // Adjust position for Player 4
            p4.transform.rotation = spawnPoint2.rotation;
        }
    }
}
