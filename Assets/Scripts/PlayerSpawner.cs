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
            SpawnMultiple(prefabs[1], spawnPoints[0], 10);
            Debug.Log("No gamepads found, 1 min");
            return;
        }

        // Spawn players
        SpawnPlayer(prefabs[0], 0, "Gamepad", null, spawnPoints[0].position, spawnPoints[0].rotation);

        for (int i = 0; i < 3; i++)
        {
            GameObject prefab = prefabs[i % prefabs.Length];
            Transform spawnPoint = spawnPoints[i % spawnPoints.Length];
            Vector3 offset = GetOffset(i);

            if (i < gamepads.Count)
            {
                SpawnPlayer(prefab, i + 1, "Gamepad", gamepads[i], spawnPoint.position + offset, spawnPoint.rotation);
            }
            else
            {
                SpawnPlayer(prefab, i + 1, "KeyboardMouse", null, spawnPoint.position + offset, spawnPoint.rotation);
            }
        }
    }

    private void SpawnPlayer(GameObject prefab, int playerIndex, string controlScheme, InputDevice device, Vector3 position, Quaternion rotation)
    {
        PlayerInput player = PlayerInput.Instantiate(prefab, playerIndex: playerIndex, controlScheme: controlScheme, pairWithDevice: device);
        player.transform.position = position;
        player.transform.rotation = rotation;
    }

    private void SpawnMultiple(GameObject prefab, Transform spawnPoint, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    private Vector3 GetOffset(int playerIndex)
    {
        switch (playerIndex)
        {
            case 2: return Vector3.right * 2; // Player 3 offset
            case 3: return Vector3.left * 2; // Player 4 offset
            default: return Vector3.zero;
        }
    }
}
