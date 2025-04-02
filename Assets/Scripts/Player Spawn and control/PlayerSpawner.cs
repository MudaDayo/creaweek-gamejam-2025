using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // Assign prefabs in the Inspector (index 0 to 4)
    public Transform[] spawnPoints; // Assign spawn points in the Inspector (index 0 to 2)

    void Start()
    {
        ReadOnlyArray<Gamepad> gamepads = Gamepad.all;

        if (gamepads.Count == 0)
        {
            // Spawn Player 0 with keyboard
            SpawnPlayer(prefabs[0], 0, "KeyboardMouse", null, spawnPoints[0].position, spawnPoints[0].rotation);
            Debug.Log("No gamepads found, Player 0 spawned with keyboard.");
            return;
        }

        HashSet<InputDevice> usedDevices = new HashSet<InputDevice>();

        // Spawn Player 0 with the first available input device
        InputDevice deviceForPlayer0 = Keyboard.current != null ? Keyboard.current : gamepads[0];
        SpawnPlayer(prefabs[0], 0, deviceForPlayer0 is Gamepad ? "Gamepad" : "KeyboardMouse", deviceForPlayer0, spawnPoints[0].position, spawnPoints[0].rotation);
        usedDevices.Add(deviceForPlayer0);

        // Spawn additional players
        for (int i = 1; i <= 3; i++)
        {
            GameObject prefab = prefabs[i % prefabs.Length];
            Transform spawnPoint = spawnPoints[i % spawnPoints.Length];
            InputDevice device = null;
            string controlScheme = "KeyboardMouse";

            // Assign a unique gamepad to each player if available
            foreach (Gamepad gamepad in gamepads)
            {
                if (!usedDevices.Contains(gamepad))
                {
                    device = gamepad;
                    controlScheme = usedDevices.Count switch
                    {
                        1 => "Gamepad 2",
                        2 => "Gamepad 3",
                        3 => "Gamepad 4",
                        _ => "Gamepad"
                    };
                    usedDevices.Add(gamepad);
                    break;
                }
            }

            // Fallback to keyboard if no gamepad is available
            if (device == null && !usedDevices.Contains(Keyboard.current))
            {
                device = Keyboard.current;
                usedDevices.Add(device);
            }

            SpawnPlayer(prefab, i, controlScheme, device, spawnPoints[i % spawnPoints.Length].position, spawnPoints[i % spawnPoints.Length].rotation);
        }
    }

    private void SpawnPlayer(GameObject prefab, int playerIndex, string controlScheme, InputDevice device, Vector3 position, Quaternion rotation)
    {
        PlayerInput player = PlayerInput.Instantiate(prefab, playerIndex: playerIndex, controlScheme: controlScheme, pairWithDevice: device);
        player.transform.SetPositionAndRotation(position, rotation);

        // Debug log to track player assignments
        string deviceName = device != null ? device.displayName : "None";
        Debug.Log($"Player {playerIndex} spawned with control scheme '{controlScheme}' and device '{deviceName}'.");
    }
}