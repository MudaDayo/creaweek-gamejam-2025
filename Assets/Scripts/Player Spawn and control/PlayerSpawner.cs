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

        if (gamepads.Count < 4)
        {
            Debug.LogError("At least 4 gamepads are required to play the game.");
            return; // Exit if there are fewer than 4 gamepads
        }

        HashSet<InputDevice> usedDevices = new HashSet<InputDevice>();

        // Spawn players with gamepads
        for (int i = 0; i < 4; i++)
        {
            GameObject prefab = prefabs[i % prefabs.Length];
            Transform spawnPoint = spawnPoints[i % spawnPoints.Length];
            Vector3 offset = GetOffset(i);

            Gamepad gamepad = gamepads[i];
            string controlScheme = $"Gamepad {i + 1}";

            usedDevices.Add(gamepad);

            SpawnPlayer(prefab, i, controlScheme, gamepad, spawnPoint.position + offset, spawnPoint.rotation);
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

    private Vector3 GetOffset(int playerIndex)
    {
        return playerIndex switch
        {
            2 => Vector3.right * 2, // Player 3 offset
            3 => Vector3.left * 2,  // Player 4 offset
            _ => Vector3.zero,
        };
    }
}
